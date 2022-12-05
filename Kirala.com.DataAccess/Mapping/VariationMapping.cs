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
    public class VariationMapping : IEntityTypeConfiguration<Variation>
    {
        public void Configure(EntityTypeBuilder<Variation> builder)
        {

        }
    }
}
