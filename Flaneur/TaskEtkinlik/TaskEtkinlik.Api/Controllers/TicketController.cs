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
    public class TicketController : CustomBaseController
    {
        private readonly IService<Ticket> _service;
        private readonly IMapper _mapper;

        public TicketController(IMapper mapper, IService<Ticket> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Save(TicketDto ticketDto)
        {
           var ticket= await _service.AddAsync(_mapper.Map<Ticket>(ticketDto));
            var ticketdto = _mapper.Map<TicketDto>(ticket);
            return CreateActionResult(CustomResponseDto<TicketDto>.Succes(201, ticketdto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var ticket= await _service.GetByIdAsync(id);
            await _service.RemoveAsync(ticket);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
