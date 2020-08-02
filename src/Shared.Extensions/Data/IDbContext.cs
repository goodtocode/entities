using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Shared.Models
{
    public interface IDbContext<TEntity> where TEntity : class, new()
    {
        EntityEntry<T> Entry<T>([NotNullAttribute] T entity) where T : class;
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}