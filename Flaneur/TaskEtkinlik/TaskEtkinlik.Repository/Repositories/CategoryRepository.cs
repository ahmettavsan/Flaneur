using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Repositories;

namespace TaskEtkinlik.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> GetCategoryByIdWithEvents(int id)
        {
            return await _appDbContext.Categories.Include(x => x.Events).Where(x =>x.Id == id).SingleOrDefaultAsync();
        }
    }
}
