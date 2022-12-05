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
    public class TransmissionMapping : IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.Property(x => x.Name).IsUnicode(true);
        }
    }
}
