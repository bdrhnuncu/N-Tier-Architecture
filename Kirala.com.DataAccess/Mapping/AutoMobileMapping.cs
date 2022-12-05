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
    public class AutoMobileMapping : IEntityTypeConfiguration<AutoMobile>
    {
        public void Configure(EntityTypeBuilder<AutoMobile> builder)
        {
            builder.HasOne(x => x.Make).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.MakeId);
            builder.HasOne(x => x.Model).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ModelId);
            builder.HasOne(x => x.Variation).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.VariationId);
            builder.HasOne(x => x.BodyType).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.BodyTypeId);
            builder.HasOne(x => x.Transmission).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.TransmissionId);
            builder.HasOne(x => x.Fuel).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.FuelId);
            builder.HasOne(x => x.Colour).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ColourId);
            builder.HasOne(x => x.WheelDrive).WithMany(x => x.AutoMobiles).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.WheelDriveId);
        }
    }
}
