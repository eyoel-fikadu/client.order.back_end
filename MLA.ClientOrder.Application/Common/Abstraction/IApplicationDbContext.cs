using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface IApplicationDbContext
    {
        DbSet<Clients> Clients { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<Lawyers> Lawyers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
