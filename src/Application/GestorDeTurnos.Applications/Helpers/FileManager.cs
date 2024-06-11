
using GestorDeTurnos.Application.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Helpers
{
    public class FileManager<Entity> : IFileManager<Entity> where Entity : class
    {
        private readonly string _root = Path.Combine(Directory.GetCurrentDirectory(), Constants.Paths.Uploads, typeof(Entity).Name);

        public async Task<string> SaveAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("El archivo no es válido.");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var folderPath = Path.Combine(_root);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<string> UpdateAsync(IFormFile file, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                Delete(fileName);
            }

            return await SaveAsync(file);
        }

        public void Delete(string fileName)
        {
            var fullFilePath = Path.Combine(_root, fileName).Replace("\\", "/");

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }
        }
    }
}