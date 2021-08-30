using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLA.ClientOrder.Domain.Entities;
using System;


namespace MLA.OrderManagement.Infrustructure.Persistance.Configuration
{
    public class LayersConfiguration : IEntityTypeConfiguration<Lawyers>
    {
        public void Configure(EntityTypeBuilder<Lawyers> builder)
        {
           
        }
    }
}
