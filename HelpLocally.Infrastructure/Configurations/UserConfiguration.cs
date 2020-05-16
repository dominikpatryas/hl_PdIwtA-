using HelpLocally.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.Login).IsRequired();
            builder.HasIndex(x => x.PasswordHash);
            builder.HasIndex(x => x.PasswordSalt);

            builder.HasIndex(x => x.Id);
        }
    }
}
