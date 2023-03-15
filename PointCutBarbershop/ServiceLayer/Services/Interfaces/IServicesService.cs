using ServiceLayer.DTOs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface IServicesService
	{
		Task CreateAsync(ServicesDto servicesDto);

		Task UpdateAsync(string Id, ServicesEditDto servicesEditDto);
		Task DeleteAsync(string id);
		Task<List<ServicesDto>> GetAllAsync();
		Task<ServicesEditDto> GetAsync(string id);
	}
}
