using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLA.ClientOrder.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.OrderManagement.Infrustructure.Persistance.Configuration
{
    public class OtherLawyersConfiguration : IEntityTypeConfiguration<OtherLawyers>
    {
        public void Configure(EntityTypeBuilder<OtherLawyers> builder)
        {
            var build = builder.ToTable("OtherLawyers");
            build.HasKey(w => new { w.LawyerId, w.OrderId});
            build.HasOne(w => w.Lawyer)
              .WithMany(wc => wc.OtherLayers)
              .HasForeignKey(w => w.LawyerId);
            build.HasOne(w => w.Order)
              .WithMany(wc => wc.OtherLawyers)
              .HasForeignKey(w => w.OrderId);
        }
    }
}
