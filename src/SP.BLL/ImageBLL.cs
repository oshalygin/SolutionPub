using System.Collections.Generic;
using Microsoft.AspNet.Http;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class ImageBLL: IImageBLL
    {

        private readonly IImageDataAccess _imageDataAcces;
        private readonly IImageUtility _imageUtility;

        public ImageBLL(IImageDataAccess imageDataAccess, IImageUtility imageUtility)
        {
            _imageDataAcces = imageDataAccess;
            _imageUtility = imageUtility;
        }

        public IEnumerable<Image> Get(int? page)
        {
            const int pageSize = 10;

            return _imageDataAcces
                .GetImages((page ?? 0), pageSize);
        }

        public Image GetImageById(int imageId)
        {
            return _imageDataAcces
                .GetImage(imageId);
        }

        public Image SaveImage(string fileName, string description, IFormFile file)
        {
            return _imageUtility
                .SaveImage(fileName, description, file);
        }

        public int GetTotalNumberOfImages()
        {
            return _imageDataAcces
                .GetTotalNumberOfImages();
        }
    }
}
