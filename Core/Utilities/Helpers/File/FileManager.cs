using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.File
{
    public class FileManager : IFileService
    {
        public bool CreateDirectoryIfNotExists(string filepath)
        {
            if(!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            return true;
        }

        public IResult Delete(string file)
        {
            throw new NotImplementedException();
        }

        public IResult Upload(string source, string destination, string fileName)
        {
            CreateDirectoryIfNotExists(destination);
            System.IO.File.Copy(source, Path.Combine(destination, fileName), true);
            return new SuccessResult();
        }

        public IResult UploadWithGuid(string source, string destination)
        {
            CreateDirectoryIfNotExists(destination);
            string newFileName = Guid.NewGuid() + Path.GetExtension(source);
            System.IO.File.Copy(source, Path.Combine(destination, newFileName), true);
            return new SuccessResult(newFileName);
        }
    }
}
