using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities;

namespace TwitterClone.DatabaseAccessLayer.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(b => b.Fullname)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(b => b.BirthDate)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
