using ServiceLayer.DTOs.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface IPricingService
	{
		Task CreateAsync(PricingDto pricingDto);

		Task UpdateAsync(string Id, PricingEditDto pricingEditDto);
		Task DeleteAsync(string id);
		Task<List<PricingDto>> GetAllAsync();
		Task<PricingEditDto> GetAsync(string id);
	}
}
