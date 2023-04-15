using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-folder";
        public FileStorageService(IHostingEnvironment webHostEnviroment)
        {
            _userContentFolder = Path.Combine(webHostEnviroment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            //throw new NotImplementedException();
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
                await Task.Run(() => File.Delete(filePath));
        }

        public string GetFileURL(string fileName)
        {
            //throw new NotImplementedException();
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            //throw new NotImplementedException();
            var filePath = Path.Combine(_userContentFolder, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
                await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
