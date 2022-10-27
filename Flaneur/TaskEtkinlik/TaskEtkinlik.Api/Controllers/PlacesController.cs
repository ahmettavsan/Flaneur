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
    public class PlacesController : CustomBaseController
    {
        private readonly IService<Place> _service;
        private readonly IMapper _mapper;

        public PlacesController(IMapper mapper, IService<Place> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var places = await _service.GetAllAsync();
            var placesdto = _mapper.Map<List<PlaceDto>>(places.ToList());
            return CreateActionResult(CustomResponseDto<List<PlaceDto>>.Succes(200, placesdto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(PlaceDto placeDto)
        {
           var place= await _service.AddAsync(_mapper.Map<Place>(placeDto));
            var newplacedto = _mapper.Map<PlaceDto>(place);
            return CreateActionResult(CustomResponseDto<PlaceDto>.Succes(201, newplacedto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(PlaceDto placeDto)
        {
            await _service.UpdateAsync(_mapper.Map<Place>(placeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var place = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(place);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
