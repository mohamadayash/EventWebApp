using Events.Infrastructure.Contexts;
using Events.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Repositories
{
    public class EventFileRepository:BaseRepository<EventFile>
    {
        public EventFileRepository(EventsContext context):base(context)
        {

        }
    }
}
