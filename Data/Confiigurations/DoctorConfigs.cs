using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Confiigurations
{
    public class DoctorConfigs : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Archived).HasDefaultValue(false);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Doctors)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
