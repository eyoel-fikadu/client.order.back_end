using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLA.ClientOrder.Domain.Entities;

namespace MLA.OrderManagement.Infrustructure.Persistance.Configuration
{
    public class UserDetailsConfiguration : IEntityTypeConfiguration<UserDetails>
    {
        public void Configure(EntityTypeBuilder<UserDetails> builder)
        {
            builder.ToTable("UserDetails");
            builder.HasIndex(t => t.UserId)
                .IsUnique();
        }
    }
}
