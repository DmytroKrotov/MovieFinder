using MovieFinder.Models;

namespace MovieFinder.Services.ImageServices
{
    public interface IImageProvider
    {
        public Task<Image> SaveUploadedFile(IFormFile file);
        public void RemoveFile(Image image);
    }
}
