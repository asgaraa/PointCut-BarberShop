using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Salon
{
	public class SalonDto
	{
		public string Id { get; set; }
        public string ImageForMen { get; set; }
        public string ImageForWomen { get; set; }
        public string TitleForMen { get; set; }
        public string Pricing { get; set; }
        public string Welcome { get; set; }
        public string AboutSalon { get; set; }
        public string TitleForWomen { get; set; }
        [NotMapped]
        public IFormFile Image1 { get; set; }
        [NotMapped]
        public IFormFile Image2 { get; set; }
    }
}
