using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Auth;
using GestorDeTurnos.Application.Dtos.User;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Wrappers;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
        /// Asynchronously registers a new user.
        /// </summary>
        /// <param name="request">The user creation request details.</param>
        /// <returns>The registration response.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterAsync(UserCreateRequest request)
        {
            var registrationResponse = await _accountService.CreateUserAccountAsync(request);
            return Ok(registrationResponse);
        }

        [HttpPost("{id}/role")]
        public async Task<ActionResult> AddRoleAsync(Guid id, [FromBody] string role)
        {
            await _accountService.AddToRoleAsync(id, role);
            return NoContent();
        }
    }
}