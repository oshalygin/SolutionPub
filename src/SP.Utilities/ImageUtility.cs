using System.IO;
using ImageProcessor;

namespace SP.Utilities
{
    public class ImageUtility: IImageUtility
    {
        public bool ValidFileExtension(string extension)
        {
            throw new System.NotImplementedException();
        }

        public ImageFactory ResizeImage(int imageWidth, int imageHeight, Stream filePath)
        {
            throw new System.NotImplementedException();
        }

        public string GetServerPath(string originalPhotoUrlPath)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveImage(ImageFactory image)
        {
            throw new System.NotImplementedException();
        }

        public bool FormatImage(ImageFactory image)
        {
            throw new System.NotImplementedException();
        }
    }

}
