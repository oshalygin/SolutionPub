using System.IO;


namespace SP.Utilities
{

    public interface IImageUtility
    {
        bool ValidFileExtension(string extension);
        string ResizeImage(int imageWidth, int imageHeight, Stream filePath);
        string GetServerPath(string originalPhotoUrlPath);
        bool SaveImage(string image);
        bool FormatImage(string image);

    }
}
