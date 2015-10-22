using System.Collections.Generic;
using Microsoft.AspNet.Http;
using SP.Entities;

namespace SP.BLL
{
    public interface IImageBLL
    {
        IEnumerable<Image> Get(int? page);
        Image GetImageById(int imageId);
        Image SaveImage(string description, IFormFile file);
        int GetTotalNumberOfImages();
    }
}
