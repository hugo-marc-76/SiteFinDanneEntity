using SiteFinAnnee2Entity.Models;
using System.ComponentModel.DataAnnotations;

namespace SiteFinAnnee2Entity.Models
{
    public class EventCarModel
    {

        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 20)]
        public string? Description { get; set; }

        [Required]
        public ImageModel? Image { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public string? Location { get; set; }

    }
}
