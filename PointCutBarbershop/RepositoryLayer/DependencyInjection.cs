using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Repositories.Interfaces;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public static class DependencyInjection
    {
		public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IGalleryRepository, GalleryRepository>();
			services.AddScoped<IHeroWrapRepository, HeroWrapRepository>();
			services.AddScoped<IPricingRepository, PricingRepository>();
			services.AddScoped<ISalonRepository, SalonRepository>();
			services.AddScoped<IServicesRepository, ServicesRepository>();
			services.AddScoped<ISettingsRepository, SettingsRepository>();
			services.AddScoped<ITestimonialRepository, TestimonialRepository>();
			services.AddScoped<ITeamRepository, TeamRepository>();








			return services;
		}
	}
}
