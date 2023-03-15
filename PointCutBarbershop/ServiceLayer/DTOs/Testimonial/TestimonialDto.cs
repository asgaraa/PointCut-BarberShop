using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Testimonial
{
	public class TestimonialDto
	{
		public string Id { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
