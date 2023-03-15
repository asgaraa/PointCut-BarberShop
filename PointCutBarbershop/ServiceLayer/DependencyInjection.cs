using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddServiceLayer(this IServiceCollection services)
		{
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IGalleryService, GalleryService>();
			services.AddScoped<IHeroWrapService, HeroWrapService>();
			services.AddScoped<IPricingService, PricingService>();
			services.AddScoped<ISalonService, SalonService>();
			services.AddScoped<IServicesService, ServicesService>();
			services.AddScoped<ISettingService, SettingsService>();
			services.AddScoped<ITeamService, TeamService>();
			services.AddScoped<ITestimonialService, TestimonialService>();
			return services;
		}
	}
}
