﻿
namespace GestorDeTurnos.Application.Dtos.User
{
    public class UserDetailResponse
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }
        public List<string>? Roles { get; set; }
    }
}
