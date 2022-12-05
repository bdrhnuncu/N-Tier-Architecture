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
    public class BodyTypeMapping : IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.Property(x => x.Name).IsUnicode(true);
        }

    }
}
