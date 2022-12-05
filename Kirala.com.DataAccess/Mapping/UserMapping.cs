using Kirala.com.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsUnicode(true);
            builder.Property(x => x.Password).HasMaxLength(20);
            builder.Property(x => x.Email).IsUnicode(true);
            builder.Property(x => x.Phone).HasMaxLength(14).IsUnicode(true);// with (+) 14 character max.
            builder.HasMany(x => x.Adverts).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
