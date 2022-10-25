using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.EntityConfigurations {
    public class AppSettingEntityConfiguration : IEntityTypeConfiguration<AppSetting> {
        public void Configure(EntityTypeBuilder<AppSetting> builder) {
            builder.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(x => x.Key)
                .IsUnique();

            builder.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
