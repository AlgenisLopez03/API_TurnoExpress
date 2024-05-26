using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "el nombre de usuario es necesario")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "la contraseña es nesecaria")]
        public string? Password { get; set; }
    }
}