using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Gender { get; set; }
        public List<BasketTicket> Baskets { get; set; }


    }
}
