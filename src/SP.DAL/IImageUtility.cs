using Microsoft.AspNet.Http;
using SP.Entities;

namespace SP.DAL
{
    public interface IImageUtility
    {
        Image SaveImage(string fileName, string description, IFormFile file);

    }
}
