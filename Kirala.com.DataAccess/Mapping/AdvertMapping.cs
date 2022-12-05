using Kirala.com.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Mapping
{
    public class AdvertMapping : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.Adverts).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Address).WithMany(x => x.Adverts).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.AddressId);
            builder.HasOne(x => x.User).WithMany(x => x.Adverts).HasForeignKey(x => x.UserId);
        }
    }
}
