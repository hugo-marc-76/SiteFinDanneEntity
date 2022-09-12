using SiteFinAnnee2Entity.Options;

namespace SiteFinAnnee2Entity.Services
{
    public class PathService
    {

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PathService(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        public string GetUploadsPath(string? filename = null, bool withWebRootPath = true)
        {

            PathOptions pathOptions = new PathOptions();

            configuration.GetSection(PathOptions.Path).Bind(pathOptions);

            var uploadsPath = pathOptions.CarEventImages;

            if(null != filename)
            {
                uploadsPath = Path.Combine(uploadsPath, filename);
            }

            return withWebRootPath ? Path.Combine(webHostEnvironment.WebRootPath, uploadsPath) : uploadsPath;

        }

    }
}
