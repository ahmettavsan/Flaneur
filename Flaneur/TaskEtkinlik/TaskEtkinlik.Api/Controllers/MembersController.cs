
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Services;

namespace TaskEtkinlik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : CustomBaseController
    {
        private readonly IAppUserServices _appUserServices;
        private readonly IService<Member> _service;
        private readonly IMapper _mapper;

        public MembersController(IMapper mapper, IService<Member> service, IAppUserServices appUserServices)
        {
            _mapper = mapper;
            _service = service;
            _appUserServices = appUserServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _service.GetAllAsync();
            var membersdto = _mapper.Map<List<MemberDto>>(members.ToList());
            return CreateActionResult(CustomResponseDto<List<MemberDto>>.Succes(200,membersdto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var member = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(member);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Save(CreateUserDto memberDto)
        {
         
            
            return CreateActionResult(await _appUserServices.CreateUserAsync(memberDto));
           
        }
        [HttpPost("[action]")]
       
        public async Task<IActionResult> Login(LoginDto login)
        {
           
            return CreateActionResult(await _appUserServices.LoginUserAsync(login));
        }
        [HttpPut]
        public async Task<IActionResult> Update(MemberDto memberDto)
        {
           
            await _service.UpdateAsync(_mapper.Map<Member>(memberDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
   
    }

}
