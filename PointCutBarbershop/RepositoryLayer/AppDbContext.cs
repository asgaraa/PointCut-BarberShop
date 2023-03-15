using DomainLayer.Configurations;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace RepositoryLayer
{
    public class AppDbContext : IdentityDbContext<AppUser>
	{


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new GalleryConfigurations());
			modelBuilder.ApplyConfiguration(new HeroWrapConfiguration());
			modelBuilder.ApplyConfiguration(new PricingConfiguration());
			modelBuilder.ApplyConfiguration(new SalonConfiguration());
			modelBuilder.ApplyConfiguration(new ServicesConfiguration());
			modelBuilder.ApplyConfiguration(new SettingsConfiguration());
			modelBuilder.ApplyConfiguration(new TeamConfiguration());
			modelBuilder.ApplyConfiguration(new TestimonialConfiguration());


			base.OnModelCreating(modelBuilder);
		}
	}
}
