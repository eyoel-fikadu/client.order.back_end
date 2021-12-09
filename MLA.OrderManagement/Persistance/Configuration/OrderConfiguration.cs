using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.OrderManagement.Infrustructure.Persistance.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.OwnsMany(b => b.LawFirmInvolved);
            builder.OwnsMany(b => b.CrossJudiciaries);
            builder.OwnsMany(b => b.AdditionalLawyers);
        }
    }
}
