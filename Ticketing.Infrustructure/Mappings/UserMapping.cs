using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.Domain.Entities.Users;

namespace Ticketing.Infrustructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(s => s.FullName).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.SecurityStamp).IsRequired();
            builder.Property(s => s.PasswordHash).IsRequired();
        }
    }
}
