using GestorDeTurnos.Application.Dtos.Auth;
using GestorDeTurnos.Application.Dtos.User;
using GestorDeTurnos.Application.Wrappers;

namespace GestorDeTurnos.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task AddToRoleAsync(Guid id, string role);

        Task<ApiResponse<LoginResponse>> AuthenticateUserAsync(LoginRequest request);
        Task<ApiResponse<UserDetailResponse>> GetUserAsync(string id);
        Task<ApiResponse<UserDetailResponse>> GetUserByUserNameAsync(string userName);
        Task<ApiResponse> CreateUserAccountAsync(UserCreateRequest userCreateRequest);
        Task<ApiResponse> UpdateUserAccountAsync(UserUpdateRequest userUpdateRequest);
        Task EndUserSessionAsync();
    }
}