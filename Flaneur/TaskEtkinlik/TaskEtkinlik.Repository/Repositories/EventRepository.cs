using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Repositories;

namespace TaskEtkinlik.Repository.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Event>> GetEventAll()
        {
            return await _appDbContext.Events.Include(x => x.Category).Include(x => x.Place).Include(x => x.Ticket).ToListAsync();
        }

        public async Task<List<Event>> GetEventsWithCategory()
        {
            //eager loading
            return await _appDbContext.Events.Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Event>> GetEventsWithPlace()
        {
            return await _appDbContext.Events.Include(x => x.Place).ToListAsync();
        }

        public async Task<List<Event>> GetEventsWithTicket()
        {
            return await _appDbContext.Events.Include(x => x.Ticket).ToListAsync();
        }
    }
}
