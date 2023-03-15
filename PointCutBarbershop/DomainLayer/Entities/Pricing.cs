using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
	public class Pricing:BaseEntity
	{
		public string Name { get; set; }
		public string Price { get; set; }
		public string Service1 { get; set; }
		public string Service2 { get; set; }
		public string Service3 { get; set; }
		public string Service4 { get; set; }
		public string Service5 { get; set; }
	}
}
