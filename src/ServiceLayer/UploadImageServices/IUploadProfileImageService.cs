namespace CRM.NexPolicy.src.ServiceLayer.UploadImageServices
{
    public interface IUploadProfileImageService
    {
        Task<string> UploadImageAsync(int id, string type, IFormFile file);
    }
}
