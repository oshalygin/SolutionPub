using System.IO;
using ImageProcessor;

namespace SP.Utilities
{

    //TODO: Truly consider this 3rd party library, seems cumbersome
    public interface IImageUtility
    {
        bool ValidFileExtension(string extension);
        ImageFactory ResizeImage(int imageWidth, int imageHeight, Stream filePath);
        string GetServerPath(string originalPhotoUrlPath);
        bool SaveImage(ImageFactory image);
        bool FormatImage(ImageFactory image);

    }
}
