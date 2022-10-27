using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category> GetCategoryByIdWithEvents(int id);
    }
}
