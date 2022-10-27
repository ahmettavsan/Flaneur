using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.Models
{
    public class Ticket:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
