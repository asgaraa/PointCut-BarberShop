using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
	public class Salon:BaseEntity
	{
		public string ImageForMen { get; set; }
		public string ImageForWomen { get; set; }

		public string TitleForMen { get; set; }
		public string Pricing { get; set; }
		public string Welcome { get; set; }
		public string AboutSalon { get; set; }
		public string TitleForWomen { get; set; }



	}
}
