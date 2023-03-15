using ServiceLayer.DTOs.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface ITestimonialService
	{
		Task CreateAsync(TestimonialDto testimonialDto);

		Task UpdateAsync(string Id, TestimonialEditDto testimonialEditDto);
		Task DeleteAsync(string id);
		Task<List<TestimonialDto>> GetAllAsync();
		Task<TestimonialEditDto> GetAsync(string id);
	}
}
