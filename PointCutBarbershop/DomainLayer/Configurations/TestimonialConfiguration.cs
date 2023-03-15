using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;

namespace DomainLayer.Configurations
{
	public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
	{
		public void Configure(EntityTypeBuilder<Testimonial> builder)
		{
			//builder.Property(m => m.Name).IsRequired();
		}

	}
}
