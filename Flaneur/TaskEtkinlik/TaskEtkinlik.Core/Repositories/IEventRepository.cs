using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.Repositories
{
    public interface IEventRepository:IGenericRepository<Event>
    {
        Task<List<Event>> GetEventsWithCategory();
        Task<List<Event>> GetEventsWithPlace( );
        Task<List<Event>> GetEventAll();
        Task<List<Event>> GetEventsWithTicket();
    }
}
