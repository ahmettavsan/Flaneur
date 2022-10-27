using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.Models
{
    public class District:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Place> Places { get; set; }
    }
}
