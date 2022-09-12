using SiteFinAnnee2Entity.Models;

namespace SiteFinAnnee2Entity.Services
{
    public class ImageService
    {

        private readonly PathService _pathService;

        public ImageService(PathService pathService)
        {
            _pathService = pathService;
        }

        public async Task<ImageModel> uploadAsync(ImageModel image)
        {

            var uploadsPath = _pathService.GetUploadsPath();

            var imageFile = image.File;

            var imageFileName = GetRandomFileName(imageFile.FileName);

            var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

            using (var fileStream = new FileStream(imageUploadPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            image.Name = imageFile.FileName;

            image.Path = _pathService.GetUploadsPath(imageFileName, withWebRootPath: false);

            return image;

        }

        private string GetRandomFileName(string filename)
        {

            return Guid.NewGuid() + Path.GetExtension(filename);

        }

    }
}
