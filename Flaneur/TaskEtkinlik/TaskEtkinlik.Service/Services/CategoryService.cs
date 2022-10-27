using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Repositories;
using TaskEtkinlik.Core.Services;
using TaskEtkinlik.Core.UnitOfWork;

namespace TaskEtkinlik.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _catRepository;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, ICategoryRepository catRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithEventsDto>> GetCategoryByIdWithEvents(int id)
        {
            var category = await _catRepository.GetCategoryByIdWithEvents(id);
            var categorydto=_mapper.Map<CategoryWithEventsDto>(category);
            return CustomResponseDto<CategoryWithEventsDto>.Succes(200, categorydto);
        }
    }
}
