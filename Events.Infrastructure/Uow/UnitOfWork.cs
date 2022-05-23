using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Events.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Uow
{
    public class UnitOfWork
    {
        protected DbContext Context { get; }

        public UnitOfWork(EventsContext context)
        {
            Context = context;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await Context.SaveChangesAsync(cancellationToken);
    }
}