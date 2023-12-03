using BaketMicroservice_Domain.BasketEntities;
using Microsoft.EntityFrameworkCore;

namespace BasketMicroserviceCleanArchitecture_Infrastracture.Application_Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Basket> Students { get; set; }
    }
}
