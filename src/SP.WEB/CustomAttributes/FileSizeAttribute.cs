using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Http;

namespace SP.WEB.CustomAttributes
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var formFile = value as IFormFile;
            return formFile != null && _maxSize > formFile.Length / 1048576;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The file size cannot exceed {_maxSize} MB";
        }
    }
}