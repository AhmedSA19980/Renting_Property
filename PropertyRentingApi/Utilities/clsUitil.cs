using FileSignatures.Formats;
using FileSignatures;
using Microsoft.Extensions.DependencyInjection;

namespace PropertyRentingApi.Utilities
{
    public class clsUitil
    {

        private readonly IConfiguration _configuration;

        public  clsUitil(IConfiguration configuration) // Constructor injection
        {
            _configuration = configuration;
        }
        public static void BinaryValidateImage(IFormFile imageFile)
        {
            try
            {

                using (var stream = imageFile.OpenReadStream())
                {
                    var inspector = new FileFormatInspector();
                    var format = inspector.DetermineFileFormat(stream);
                    if (format == null || !(format is Jpeg || format is Png || format is Gif))
                    {
                        throw new ArgumentException("Invalid image file format.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid file format.");

            };
        }
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
        public static bool IsFileIsEmpty(IFormFile imageFile)
        {
            return imageFile != null ? true : false;
        }

     

        public static void DeleteFile(IFormFile image ,string imagePath)
        {

            bool isEmptyFile = IsFileIsEmpty(image);
            if(imagePath != null && isEmptyFile )
            {
                File.Delete(imagePath); 
            }
        }
        public static  async Task<string> UploadPropertyImages(IFormFile imageFile, IConfiguration _configuration, bool Validation = true)
        {
            return await UploadImage(imageFile, _configuration, Validation  );
        }

        public static async Task<string> UploadPersonImage(IFormFile imageFile, IConfiguration _configuration, bool Validation = true)
        {
            return await UploadImage(imageFile, _configuration, Validation, "Person");
        }

        public static async Task<string> UploadImage(IFormFile imageFile, IConfiguration _configuration, bool Validation = true , string subfolder = "" )
        {

            if (Validation)
            {

                if (imageFile == null || imageFile.Length == 0)
                {


                    throw new ArgumentException("File is empty or null.");

                }

                long maxFileSize = _configuration.GetValue<long>("UploadSettings:MaxFileSizeMB") * 1024 * 1024;
                //long maxFileSize = 5 * 1024 * 1024; // 5MB (adjust as needed)
                if (imageFile.Length > maxFileSize)
                {
                    throw new ArgumentException($"File size exceeds the allowed limit of {maxFileSize / (1024 * 1024)}MB.");
                }


                // Content Type Validation
                string contentType = imageFile.ContentType;
                if (!contentType.StartsWith("image/"))
                {
                    throw new ArgumentException("Invalid file type. Only image files are allowed.");
                }

                // Add more specific content type checks if needed
                if (contentType != "image/jpeg" && contentType != "image/png" && contentType != "image/gif")
                {
                    throw new ArgumentException("Invalid image type. Only JPEG, PNG, and GIF images are allowed.");
                }

                BinaryValidateImage(imageFile);
                  var uploadDirectory = $@"D:\RentingPropertySystem\{subfolder}";

               


                  var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                  var filePath = Path.Combine(uploadDirectory, fileName);
                  if (!Directory.Exists(uploadDirectory))
                  {
                      Directory.CreateDirectory(uploadDirectory);
                  }




                  using (var stream = new FileStream(filePath, FileMode.Create))
                  {
                      await imageFile.CopyToAsync(stream);
                  }



                  return filePath;
          


            }

            return null;

        }

    }
}
