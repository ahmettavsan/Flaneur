using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.DTOs
{
    public class GetEventAllDto:EventDto
    {
        public PlaceDto Place { get; set; }
        public List<TicketDto> Ticket { get; set; }
        public CategoryDto Category { get; set; }
    }
}
