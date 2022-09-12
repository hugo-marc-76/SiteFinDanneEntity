using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteFinAnnee2Entity.Models
{
    public class ImageModel
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Path { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile? File { get; set; }

        public int EventCarModelId { get; set; }

        public virtual EventCarModel? EventCarModel { get; set; }

    }
}
