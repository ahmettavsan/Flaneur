using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.Models
{
    public class BasketTicket:BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        
       
        public string AppUserName { get; set; }
        [ForeignKey("AppUserName")]
        
        public AppUser AppUser { get; set; }
        

    }
}
