namespace GestorDeTurnos.Application.Dtos.Auth
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public List<string>? Roles { get; set; }
        public bool IsVerified { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}