using CRM.NexPolicy.src.DataLayer.Models.UploadImages.ProfileImages;
using CRM.NexPolicy.src.DataLayer.Repository.AgencyRepository;
using System.Drawing.Imaging;
using System.Drawing;

namespace CRM.NexPolicy.src.ServiceLayer.UploadImageServices
{
    public class UploadProfileImageService : IUploadProfileImageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAgencyRepository _agencyRepository;
        private readonly string _baseUrl = "https://localhost:7204/";

        public UploadProfileImageService(IWebHostEnvironment env, IAgencyRepository agencyRepository)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _agencyRepository = agencyRepository;
        }

        public async Task<string> UploadImageAsync(int id, string type, IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is missing.");

            var folder = type.ToLower() switch
            {
                "agency" => "agency-logos",
                "agent" => "agent-photos",
                _ => throw new ArgumentException("Invalid type. Must be 'agency' or 'agent'.")
            };

            var uploadsPath = Path.Combine(_env.WebRootPath, folder);
            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var fileExt = ".jpg"; // ⚠️ Forzamos salida a JPG
            var fileName = $"{type}_{id}{fileExt}";
            var filePath = Path.Combine(uploadsPath, fileName);

            using var imageStream = file.OpenReadStream();
            using var originalImage = Image.FromStream(imageStream);
            using var thumbnail = new Bitmap(80, 80);
            using var graphics = Graphics.FromImage(thumbnail);

            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(originalImage, 0, 0, 80, 80);

            thumbnail.Save(filePath, ImageFormat.Jpeg);

            var relativeUrl = $"/{folder}/{fileName}".Replace("\\", "/");
            var fullUrl = $"{_baseUrl}/{folder}/{fileName}".Replace("\\", "/");

            await _agencyRepository.UpdateProfileImageUrlAsync(id, relativeUrl);
            return fullUrl;
        }

    }
}
 