using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Core.Services
{
    public interface IAppUserServices
    {
        //Task<CustomResponseDto<NoContentDto>> CreateUserAsync(CreateUserDto newuser);
        Task<CustomResponseDto<CreateUserDto>> CreateUserAsync(CreateUserDto newuser);

        Task<CustomResponseDto<UserAppDto>> LoginUserAsync(LoginDto loginDto);
    }
}
