
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using SP.Entities;

namespace SP.DAL
{
    public interface IImageDataAccess
    {

        IEnumerable<Image> GetImages(int page, int pageSize);
        Image GetImage(int imageId);
        int GetTotalNumberOfImages();
    }
}
