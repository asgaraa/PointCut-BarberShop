using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
	public class SettingsConfiguration : IEntityTypeConfiguration<Settings>
	{
		public void Configure(EntityTypeBuilder<Settings> builder)
		{
			//builder.Property(m => m.Name).IsRequired();
		}
	}
}
