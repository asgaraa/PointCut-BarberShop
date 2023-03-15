using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Common
{
    public class BaseEntity
    {
		public string Id { get; set; }
		public bool SoftDelete { get; set; }
		public DateTime CreatTime { get; set; } = DateTime.Now;
	}
}
