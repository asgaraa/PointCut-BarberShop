using ServiceLayer.DTOs.HeroWrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface IHeroWrapService
	{
		Task CreateAsync(HeroWrapDto movieDto);

		Task UpdateAsync(string Id, HeroWrapEditDto heroWrapEditDto);
		Task DeleteAsync(string id);
		Task<List<HeroWrapDto>> GetAllAsync();
		Task<HeroWrapEditDto> GetAsync(string id);
	}
}
