using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Auth;
using GestorDeTurnos.Application.Dtos.Establishment;
using GestorDeTurnos.Application.Dtos.User;
using GestorDeTurnos.Application.Interfaces.Helpers;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Services;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    /// <summary>
    /// Controller for managing account-related actions such as login, logout, and registration.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IFileManager<CustomIdentityUser> _fileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        public AccountController(IAccountService accountService, IFileManager<CustomIdentityUser> fileManager)
        {
            _accountService = accountService;
            _fileManager = fileManager;
        }

        /// <summary>
        /// Asynchronously logs in a user.
        /// </summary>
        /// <param name="request">The login request details.</param>
        /// <returns>The login response.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> LoginAsync(LoginRequest request)
        {
            var loginResponse = await _accountService.AuthenticateUserAsync(request);
            return Ok(loginResponse);
        }

        /// <summary>
        /// Asynchronously logs out the current user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [HttpGet("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            await _accountService.EndUserSessionAsync();
            return NoContent();
        }

        /// <summary>
        /// Retrieves a user's details based on their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An ApiResponse containing the user's detail response data.</returns>
        [HttpGet("userbyid/{id}")]
        public async Task<ActionResult<ApiResponse<UserDetailResponse>>> GetUserById(string id)
        {
            var response = await _accountService.GetUserAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a user's details based on their username.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>An ApiResponse containing the user's detail response data.</returns>
        [HttpGet("userbyusername/{userName}")]
        public async Task<ActionResult<ApiResponse<UserDetailResponse>>> GetUserByUserName(string userName)
        {
            var response = await _accountService.GetUserByUserNameAsync(userName);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a user's details based on their username.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>An ApiResponse containing the user's detail response data.</returns>
        [HttpGet("users")]
        public async Task<ActionResult<ApiResponse<UserDetailResponse>>> GetUserByUsers(string username = null)
        {
            var response = await _accountService.GetUsersAsync(username);
            return Ok(response);
        }

        /// <summary>
        /// Asynchronously registers a new user.
        /// </summary>
        /// <param name="request">The user creation request details.</param>
        /// <returns>The registration response.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterAsync(UserCreateRequest request)
        {
            var imageName = string.Empty;

            if(request.ImageFile != null)
            {
                imageName = await _fileManager.SaveAsync(request.ImageFile);
            }

            request.ProfileImage = imageName;

            var registrationResponse = await _accountService.CreateUserAccountAsync(request);
            return Ok(registrationResponse);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutEstablishment(string id, [FromForm] UserUpdateRequest request)
        {
            if (request.ImageFile != null)
            {
                request.ProfileImage = await _fileManager.UpdateAsync(request.ImageFile, request.ProfileImage);
            }

            await _accountService.UpdateUserAccountAsync(request);

            return NoContent();
        }

        [HttpPost("{id}/role")]
        public async Task<ActionResult> AddRoleAsync(Guid id, [FromBody] string role)
        {
            await _accountService.AddToRoleAsync(id, role);
            return NoContent();
        }
    }
}