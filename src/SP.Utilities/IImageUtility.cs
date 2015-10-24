using System.IO;


namespace SP.Utilities
{

    //TODO: Truly consider this 3rd party library, seems cumbersome
    public interface IImageUtility
    {
        bool ValidFileExtension(string extension);
        string ResizeImage(int imageWidth, int imageHeight, Stream filePath);
        string GetServerPath(string originalPhotoUrlPath);
        bool SaveImage(string image);
        bool FormatImage(string image);

    }
}
