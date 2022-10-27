using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.DTOs
{
    public class BasketTicketDto:BaseDto
    {
        public int EventId { get; set; }
        
        public string AppUserName { get; set; }
      
    }
}
