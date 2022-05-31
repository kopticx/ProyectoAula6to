using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace PapeleriaIPN.Models
{
    public class UploadImage
    {
        private readonly IConfiguration configuration;
        private Cloudinary cloudinary;

        public UploadImage(IConfiguration configuration)
        {
            this.configuration = configuration;
            Account account = new Account(
            configuration["cloudinaryKeys:CloudName"],
            configuration["cloudinaryKeys:ApiKey"],
            configuration["cloudinaryKeys:ApiSecret"]);

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public string Upload(string ruta)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@$"C:\Users\kevin\Downloads\{ruta}")
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            var url = uploadResult.Url.ToString();

            return url;
        }
    }
}
