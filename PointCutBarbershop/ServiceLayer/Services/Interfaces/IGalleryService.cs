using ServiceLayer.DTOs.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface IGalleryService
	{
		Task CreateAsync(GalleryDto movieDto);

		Task UpdateAsync(string Id, GalleryEditDto movieEditDto);
		Task DeleteAsync(string id);
		Task<List<GalleryDto>> GetAllAsync();
		Task<GalleryEditDto> GetAsync(string id);
	}
}
