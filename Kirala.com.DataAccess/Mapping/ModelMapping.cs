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
    public class ModelMapping : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Name).IsUnicode(true);
           // builder.HasOne(x => x.Make).WithMany().IsRequired().HasForeignKey(x=>x.MakeId).HasConstraintName("FK_Models_Makes_MakeId");
        }

    }
}
