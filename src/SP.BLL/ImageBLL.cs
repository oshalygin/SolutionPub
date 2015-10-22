using System.Collections.Generic;
using Microsoft.AspNet.Http;
using SP.Entities;

namespace SP.BLL
{
    public class ImageBLL: IImageBLL
    {
        public IEnumerable<Image> Get(int? page)
        {
            throw new System.NotImplementedException();
        }

        public Image GetImageById(int imageId)
        {
            throw new System.NotImplementedException();
        }

        public Image SaveImage(string description, IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public int GetTotalNumberOfImages()
        {
            throw new System.NotImplementedException();
        }
    }
}
