using MovieFinder.Models;

namespace MovieFinder.Services.ImageServices
{
    public class ImageProvider : IImageProvider
    {
        private readonly IWebHostEnvironment _environment;
        public ImageProvider(IWebHostEnvironment webHostEnvironment)
        {
            _environment = webHostEnvironment;
        }

        public async Task<Image> SaveUploadedFile(IFormFile file)
        {
            var guid = Guid.NewGuid().ToString().ToLower();
            string filename = guid + Path.GetExtension(file.FileName);
            string fullFilename = Path.Combine(_environment.WebRootPath, "uploads", filename);
            using (var localFile = System.IO.File.OpenWrite(fullFilename))
            {
                await file.CopyToAsync(localFile);
            }
            return new Image() { Name = filename };
        }

        public void RemoveFile(Image image)
        {
            var fullFileName = Path.Combine(_environment.WebRootPath, "uploads", image.Name);
            File.Delete(fullFileName);
        }
    }
}
