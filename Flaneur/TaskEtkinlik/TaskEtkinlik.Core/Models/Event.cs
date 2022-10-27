using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.Models
{
    public class Event : BaseEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }//event tarihi
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public List<Ticket> Ticket { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImagePath { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
    }
}
