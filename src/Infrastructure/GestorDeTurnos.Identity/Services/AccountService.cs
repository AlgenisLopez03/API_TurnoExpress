using AutoMapper;
using Azure.Core;
using GestorDeTurnos.Application.Configs;
using GestorDeTurnos.Application.Constants;
using GestorDeTurnos.Application.Dtos.Auth;
using GestorDeTurnos.Application.Dtos.User;
using GestorDeTurnos.Application.Exceptions;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                UserName = user.UserName,
                ProfileImage = user.ProfileImage,
                Email = user.Email,
                IsVerified = user.EmailConfirmed,
                Roles = roleList,
                ExpiresIn = _jwtConfig.DurationInMinutes
            };

            var response = new ApiResponse<LoginResponse>(authentication);
            response.Message = "Successs Authentication.";

            return response;
        }

        /// <summary>
        /// Retrieves a user's details based on their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An ApiResponse containing the user's detail response data.</returns>
        public async Task<ApiResponse<UserDetailResponse>> GetUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new BadRequestException($"No Accounts Registered with id: {id}.");
            }

            var roleList = (List<string>)await _userManager.GetRolesAsync(user);


            var userDetail = new UserDetailResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                ProfileImage = user.ProfileImage,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = roleList
            };

            var response = new ApiResponse<UserDetailResponse>(userDetail);
            response.Message = "Successs user retrieve.";

            return response;
        }

        /// <summary>
        /// Retrieves a user's details based on their username.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>An ApiResponse containing the user's detail response data.</returns>
        public async Task<ApiResponse<UserDetailResponse>> GetUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                throw new BadRequestException($"No Accounts Registered with username: {userName}.");
            }

            var roleList = (List<string>)await _userManager.GetRolesAsync(user);


            var userDetail = new UserDetailResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                ProfileImage = user.ProfileImage,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = roleList
            };

            var response = new ApiResponse<UserDetailResponse>(userDetail);
            response.Message = "Successs user retrieve.";

            return response;
        }

        /// <summary>
        /// Retrieves user details based on the provided username. If no username is provided, retrieves all users.
        /// </summary>
        /// <param name="userName">The username of the user to filter by. If null or empty, retrieves all users.</param>
        /// <returns>An ApiResponse containing a list of UserDetailResponse with the details of the retrieved users.</returns>
        public async Task<ApiResponse<List<UserDetailResponse>>> GetUsersAsync(string? userName = null)
        {
            var users = string.IsNullOrEmpty(userName)
                ? await _userManager.Users.ToListAsync()
                : await _userManager.Users
                    .Where(u => u.UserName.Contains(userName))
                    .ToListAsync();

            if (users == null || !users.Any())
            {
                throw new BadRequestException($"No accounts found with username containing: {userName ?? "any username"}.");
            }
            var userDetails = new List<UserDetailResponse>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                var userDetailsResponse = new UserDetailResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    ProfileImage = user.ProfileImage,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles.ToList()
                };
                userDetails.Add(userDetailsResponse);
            }

            var response = new ApiResponse<List<UserDetailResponse>>(userDetails);


            response.Message = "Users retrieved successfully.";

            return response;
        }

        /// <summary>
        /// Registers a new user into the system.
        /// </summary>
        /// <param name="userCreateRequest">The user registration data.</param>
        /// <returns>An ApiResponse indicating the result of the registration process.</returns>
        public async Task<ApiResponse> CreateUserAccountAsync(UserCreateRequest userCreateRequest)
        {
            var response = new ApiResponse();

            var userWithSameUserName = await _userManager.FindByNameAsync(userCreateRequest.UserName);

            if (userWithSameUserName != null)
            {
                throw new BadRequestException($"The username {userCreateRequest.UserName} is already in use. Please choose a differente one.");
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(userCreateRequest.Email);

            if (userWithSameEmail != null)
            {
                throw new BadRequestException($"The email address {userCreateRequest.Email} is already in use. Please choose a different one.");
            }

            var newUser = _mapper.Map<CustomIdentityUser>(userCreateRequest);
            newUser.EmailConfirmed = true;

            var reuslt = await _userManager.CreateAsync(newUser, userCreateRequest.Password);

            if (reuslt.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, Role.Custom.ToString());
                response.Message = "User registered Succesfully";
            }
            else
            {
                response.Message = "An error occurred";
            }

            return response;
        }

        /// <summary>
        /// Update the information of an user into the system.
        /// </summary>
        /// <param name="userUpdateRequest">The user data to update.</param>
        /// <returns>An ApiResponse indicating the result of the updating process.</returns>
        public async Task<ApiResponse> UpdateUserAccountAsync(UserUpdateRequest userUpdateRequest)
        {
            var response = new ApiResponse();

            var user = await _userManager.FindByIdAsync(userUpdateRequest.Id);

            if(user == null)
            {
                response.Message = $"No existe usuario registrado con {userUpdateRequest.Id}";
            }

            _mapper.Map(userUpdateRequest, user);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                response.Message = "User Updated Succesfully";
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