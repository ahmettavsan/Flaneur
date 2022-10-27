using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.DTOs
{
    public class EventDto:BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }//event tarihi
        public int PlaceId { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
    }
}
