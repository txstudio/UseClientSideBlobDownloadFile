using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UseClientSideBlobDownloadFile
{
    public class FileStorage
    {
        const string directoryName = "files";
        const string fileName = "doc.pdf";

        private readonly IHostingEnvironment _enviroment;

        public FileStorage(IHostingEnvironment enviroment)
        {
            this._enviroment = enviroment;
        }

        public byte[] GetDocument()
        {
            var _dirPath = Path.Combine(this._enviroment.WebRootPath, directoryName);
            var _filePath = Path.Combine(_dirPath, fileName);
            var _buffer = File.ReadAllBytes(_filePath);

            return _buffer;
        }

    }
}
