using System.Text;

namespace UtillsLayer
{
    public class clsMemeType
    {
        public static string GetMimeType(string filePath)
        {

            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream",
            };
        }

    }
}
