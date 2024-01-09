using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Core.Entities;

namespace TwitterClone.DatabaseAccessLayer.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(table => table.Name)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
