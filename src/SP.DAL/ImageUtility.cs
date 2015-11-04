
using System;
using System.IO;
using Microsoft.AspNet.Http;
using Microsoft.Dnx.Runtime;
using Microsoft.Net.Http.Headers;
using SP.Entities;


namespace SP.DAL
{
    public class ImageUtility: IImageUtility
    {        
        private const string BlogImageDatabasePath = @"~/Content/img/BlogImages/";        
        private readonly IApplicationEnvironment _applicationEnvironment;

        public ImageUtility(IApplicationEnvironment applicationEnvironment)
        {
            _applicationEnvironment = applicationEnvironment;            
        }

        //TODO: Need to be able to test this...FrameworkIssues
        public Image SaveImage(string fileName, string description, IFormFile file)
        {
            Image image;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileContent = reader.ReadToEnd();
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                image = new Image
                {
                    FileName = parsedContentDisposition.FileName,
                    Content = fileContent,
                    Description = description,
                    UploadDate = DateTime.UtcNow,
                    ImagePath = Path.Combine(_applicationEnvironment.ApplicationBasePath, BlogImageDatabasePath, parsedContentDisposition.FileName)                    
                };
            }

            return image;
        }
    }
}
