using ServiceLayer.DTOs.Salon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface ISalonService
	{
		Task CreateAsync(SalonDto salonDto);

		Task UpdateAsync(string Id, SalonEditDto salonEditDto);
		Task DeleteAsync(string id);
		Task<List<SalonDto>> GetAllAsync();
		Task<SalonEditDto> GetAsync(string id);
	}
}
