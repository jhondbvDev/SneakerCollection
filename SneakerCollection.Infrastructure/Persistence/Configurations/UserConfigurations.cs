using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.User;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Infrastructure.Persistence.Configurations
{
	public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
            builder.Property(m => m.Password)
                .HasMaxLength(250);
            builder.OwnsMany(m => m.Sneakers, sn =>
            {
                builder.ToTable("Sneakers");
                sn.WithOwner().HasForeignKey("UserId");
                sn.HasKey(m => m.Id);
                sn.Property(m => m.Id).ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    value => SneakerId.Create(value));
                sn.Property(m => m.Name)
                    .HasMaxLength(250);
                sn.Property(m => m.Brand)
                    .HasMaxLength(250);
                sn.Property(m => m.Price);
                sn.Property(m => m.Rate);
                sn.Property(m => m.Year);
                sn.Property(m => m.Size);
                
            });
        }
    }
}

