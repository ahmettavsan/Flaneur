using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Services;

namespace TaskEtkinlik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketTicketController : CustomBaseController
    {
        private readonly IService<BasketTicket> _service;
        private readonly IMapper _mapper;

        public BasketTicketController(IService<BasketTicket> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
       
        public async Task<IActionResult> Add(BasketTicketDto basketTicketDto)
        {
            var datas = await _service.Where(x => x.AppUserName == basketTicketDto.AppUserName && x.EventId==basketTicketDto.EventId).ToListAsync();
            if (datas.Any())
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(400, "Event Already Exists"));
            }

            var basketTicket = _mapper.Map<BasketTicket>(basketTicketDto);
            var newBasketTicket=  await _service.AddAsync(basketTicket);
           
            if (newBasketTicket!=null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));

            }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(400, "Operation Failed"));

        }
        [HttpGet("[action]/{name:alpha}")]
        public async Task<IActionResult> GetTicketByUserId(string name)
        {
            var datas = await _service.Where(x => x.AppUserName == name).ToListAsync();
            var datasDto = _mapper.Map<List<BasketTicketDto>>(datas);
            if (datas == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(204, "Not Found"));
            }
            return CreateActionResult(CustomResponseDto<List<BasketTicketDto>>.Succes(200, datasDto));
        }
    }
}
