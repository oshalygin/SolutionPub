
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using SP.Entities;

namespace SP.DAL
{
    public class ImageDataAccess : IImageDataAccess
    {
        private readonly BlogContext _context;

        public ImageDataAccess()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Image> GetImages(int page, int pageSize)
        {
            return _context
                .Images
                .OrderBy(x => x.UploadDate)
                .Skip(page*pageSize)
                .Take(pageSize);
        }

        public Image GetImage(int imageId)
        {
            return _context
                .Images
                .Single(x => x.Id == imageId);
        }

        public int GetTotalNumberOfImages()
        {
            return _context
                .Images
                .Count();
        }
    }
}