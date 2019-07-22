using FurkanCelik.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurkanCelik.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<DersSecimi> DersSecimi { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
