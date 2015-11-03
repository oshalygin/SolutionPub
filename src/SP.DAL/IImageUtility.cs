using Microsoft.AspNet.Http;

namespace SP.DAL
{
    public interface IImageUtility
    {
        bool SaveImage(string fileName, string description, IFormFile file);

    }
}
