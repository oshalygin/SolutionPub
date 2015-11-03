
using System.IO;
using Microsoft.AspNet.Http;
using Microsoft.Dnx.Runtime;

namespace SP.DAL
{
    public class ImageUtility: IImageUtility
    {        
        private const string BlogImageDatabasePath = "~/Content/img/BlogImages/";

        private readonly IApplicationEnvironment _applicationEnvironment;

        public ImageUtility(IApplicationEnvironment applicationEnvironment)
        {
            _applicationEnvironment = applicationEnvironment;
        }

        //TODO: This needs work and testing
        public bool SaveImage(string fileName, string description, IFormFile file)
        {
            var serverBasePath = _applicationEnvironment.ApplicationBasePath;

            return false;
        }
    }
}
