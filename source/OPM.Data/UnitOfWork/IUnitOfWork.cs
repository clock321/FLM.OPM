using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OPM.Data
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        int Save();
        Task<int> SaveAsync();
        TContext Context { get; }
    }
}
