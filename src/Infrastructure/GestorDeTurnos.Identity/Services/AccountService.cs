using AutoMapper;
using GestorDeTurnos.Application.Configs;
using GestorDeTurnos.Application.Dtos.Auth;
using GestorDeTurnos.Application.Dtos.User;
using GestorDeTurnos.Application.Exceptions;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestorDeTurnos.Identity.Services
{
    /// <summary>
    /// Provides account related services like login and registration.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private readonly string _userName;

        /// <summary>
        /// Initializes a new instance of the AccountService.
        /// </summary>
        public AccountService(
            UserManager<CustomIdentityUser> userManager,
            SignInManager<CustomIdentityUser> signInManager,
            IOptions<JwtConfig> jwtConfig,
            IMapper mapper,
             IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig.Value;
            _mapper = mapper;
            _userName = httpContextAccessor.HttpContext.GetUserName();
        }

        /// <summary>
        /// Authenticates a user and generates a login response with a JWT token.
        /// </summary>
        /// <param name="request">The login request data.</param>
        /// <returns>An ApiResponse containing the login response data.</returns>

        public async Task<ApiResponse<LoginResponse>> AuthenticateUserAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new BadRequestException($"No Accounts Registered with {request.UserName}.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Invalid Password for {request.UserName}");
            }

            if (!user.EmailConfirmed)
            {
                throw new BadRequestException($"Account Not Comfirmed for {user.Email}");
            }

            var accessToken = await GenerateAccessTokenAsync(user);
            var roleList = (List<string>)await _userManager.GetRolesAsync(user);

            var authentication = new LoginResponse
            {
                Id = user.Id,
                AccessToken = accessToken,
                Email = user.Email,
                UserName = user.UserName,
                IsVerified = user.EmailConfirmed,
                Roles = roleList,
                ExpiresIn = _jwtConfig.DurationInMinutes
            };

            var response = new ApiResponse<LoginResponse>(authentication);
            response.Message = "Successs Authentication.";

            return response;
        }

        /// <summary>
        /// Registers a new user into the system.
        /// </summary>
        /// <param name="userCreateRequest">The user registration data.</param>
        /// <returns>An ApiResponse indicating the result of the registration process.</returns>

        public async Task<ApiResponse> CreateUserAccountAsync(UserCreateRequest userCreateRequest)
        {
            var newUser = _mapper.Map<CustomIdentityUser>(userCreateRequest);
            newUser.EmailConfirmed = true;

            var reuslt = await _userManager.CreateAsync(newUser, userCreateRequest.Password);
            var response = new ApiResponse();

            if (reuslt.Succeeded)
            {
                response.Message = "User registered Succesulfully";
            }
            else
            {
                response.Message = "An error occurred";
            }

            return response;
        }

        /// <summary>
        /// Generates an access token for a given ApplicationUser.
        /// </summary>
        /// <param name="user">The ApplicationUser for whom the token is to be generated.</param>
        /// <returns>A JWT token as a string.</returns>
        private async Task<string> GenerateAccessTokenAsync(CustomIdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roleList = await _userManager.GetRolesAsync(user);

            var userClaims = await _userManager.GetClaimsAsync(user);
            var rolesClaims = roleList.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(rolesClaims);

            var securityToken = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtConfig.DurationInMinutes),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        /// <summary>
        /// Logs out the currently logged-in user.
        /// </summary>
        public async Task EndUserSessionAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task AddToRoleAsync(Guid id, string role)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new NotFoundException("User", id);
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}