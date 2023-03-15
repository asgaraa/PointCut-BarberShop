using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Gallery
{
	public class GalleryDto
	{
		public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Project { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
