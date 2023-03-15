using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Team
{
	public class TeamEditDto
	{
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Job { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
