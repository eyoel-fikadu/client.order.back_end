using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLA.ClientOrder.Domain.Entities;


namespace MLA.OrderManagement.Infrustructure.Persistance.Configuration
{
    public class ClientsConfiguration : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Client");
            builder.Property(t => t.Client_name)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .OwnsOne(b => b.Address);
        }
    }
}
