using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
	public class Testimonial:BaseEntity
	{
		public string Image { get; set; }
		public string Comment { get; set; }
		public string Name { get; set; }
		public string Job { get; set; }
	}
}
