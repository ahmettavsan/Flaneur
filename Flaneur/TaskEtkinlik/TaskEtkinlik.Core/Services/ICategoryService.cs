using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<CustomResponseDto<CategoryWithEventsDto>> GetCategoryByIdWithEvents(int id);
    }
}
