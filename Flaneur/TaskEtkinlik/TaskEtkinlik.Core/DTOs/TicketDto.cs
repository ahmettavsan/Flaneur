using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.DTOs
{
    public class TicketDto:BaseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; }
    }
}
