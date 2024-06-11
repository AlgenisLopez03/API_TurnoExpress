
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Interfaces.Helpers
{
    public interface IFileManager<Entity> where Entity : class
    {
        Task<string> SaveAsync(IFormFile file);
        Task<string> UpdateAsync(IFormFile file, string imageName);
        void Delete(string imageName);
    }
}
