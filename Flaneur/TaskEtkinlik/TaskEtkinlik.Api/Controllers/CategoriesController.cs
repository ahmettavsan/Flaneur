using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Services;

namespace TaskEtkinlik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly IService<Category> _service;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, ICategoryService categoryService, IService<Category> service)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _service = service;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryWithEvents(int id)
        {
            return CreateActionResult( await _categoryService.GetCategoryByIdWithEvents(id));

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            var categoriesdto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Succes(200,categoriesdto)); 
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto newcategoryDto)
        {
            var category = await _service.AddAsync(_mapper.Map<Category>(newcategoryDto));
            var categorydto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Succes(200, categorydto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(category);
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
