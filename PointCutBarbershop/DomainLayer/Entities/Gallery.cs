﻿using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
	public class Gallery:BaseEntity
	{
		public string Image { get; set; }
		public string Title { get; set; }
		public string Project { get; set; }
	}
}
