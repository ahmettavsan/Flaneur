﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.DTOs
{
    public class EventWithCategoryDto:EventDto
    {
        public CategoryDto Category { get; set; }

    }
}
