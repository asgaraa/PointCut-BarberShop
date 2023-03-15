using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Services
{
	public class ServicesEditDto
	{
        public string Id { get; set; }
        public string? FlaIconName { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}
