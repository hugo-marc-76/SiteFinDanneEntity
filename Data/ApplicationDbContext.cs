using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteFinAnnee2Entity;
using SiteFinAnnee2Entity.Models;

namespace SiteFinAnnee2Entity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventCarModel>? EventCarModel { get; set; }
        public DbSet<ImageModel>? ImageModel { get; set; }
    }
}