using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Services;
using TaskEtkinlik.Core.UnitOfWork;
using TaskEtkinlik.Repository;

namespace TaskEtkinlik.Service.Services
{
    public class AppUserServices : IAppUserServices
    {
        private readonly SignInManager<AppUser> _userSignManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;


        public AppUserServices(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper, AppDbContext context, SignInManager<AppUser> userSignManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _userSignManager = userSignManager;
            _roleManager = roleManager;
        }

        public async Task<CustomResponseDto<CreateUserDto>> CreateUserAsync(CreateUserDto newuser)
        {
            var userone = new AppUser()
            {
                UserName = newuser.UserName,
                Email = newuser.Email,
                Name = newuser.Name,
                Surname = newuser.Surname
            };
            var identityresult = await _userManager.CreateAsync(userone, newuser.Password);
            List<IdentityError> error = identityresult.Errors.ToList();
            _context.SaveChanges();
            await _unitOfWork.CommitAsync();
             
            if (identityresult.Succeeded)
            {
                
                await _userManager.AddToRoleAsync(userone, "Member");
                
                
                return CustomResponseDto<CreateUserDto>.Success(200);
               
            }
            return CustomResponseDto<CreateUserDto>.Fail(404, "Kayıt Yapılamadı");


            

        }

        public async Task<CustomResponseDto<UserAppDto>> LoginUserAsync(LoginDto loginDto)
        {
           var signinResult= await _userSignManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, true);
          

            if (signinResult.Succeeded)
            {
                var user=await _userManager.FindByNameAsync(loginDto.UserName);
                var userdto = _mapper.Map<UserAppDto>(user);
                return CustomResponseDto<UserAppDto>.Succes(200,userdto);
            }
            else if (signinResult.IsLockedOut)
            {
              
            }
            else if (signinResult.IsNotAllowed)
            {

            }
            return CustomResponseDto<UserAppDto>.Fail(404,"Email Or Password is not true");

        }
        public async Task<CustomResponseDto<UserAppDto>> ByName(string name)
        {
          var appUser=  await _userManager.FindByNameAsync(name);
            var appUserDto=_mapper.Map<UserAppDto>(appUser);
            if (appUser==null)
            {
                return CustomResponseDto<UserAppDto>.Fail(404, "User is not found");
            }
            return CustomResponseDto<UserAppDto>.Succes(200,appUserDto);
        }
    }
}
