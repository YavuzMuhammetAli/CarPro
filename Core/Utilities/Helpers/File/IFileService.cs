using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.File
{
    public interface IFileService
    {
        public IResult Upload(string source, string destination, string fileName);
        public IResult UploadWithGuid(string source, string destination);
        public IResult Delete(string file);
        public bool CreateDirectoryIfNotExists(string filepath);
    }
}
