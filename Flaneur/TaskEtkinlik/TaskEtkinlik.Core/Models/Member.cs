using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.Models
{
    public class Member:BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public List<BasketTicket> Ticket { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
