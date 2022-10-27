using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.DTOs
{
    public class EventWithTicketsDto:EventDto
    {
        public List<TicketDto> Ticket { get; set; }

    }
}
