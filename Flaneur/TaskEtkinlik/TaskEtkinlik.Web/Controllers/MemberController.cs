using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using TaskEtkinlik.Core.DTOs;
using TaskEtkinlik.Web.Services;

namespace TaskEtkinlik.Web.Controllers
{
    [AutoValidateAntiforgeryToken]//------------------
    public class MemberController : BaseController
    {
       
        private readonly MemberApiService _memberApiService;
      
        public MemberController(MemberApiService memberApiService)
        {
            _memberApiService = memberApiService;
        }

        public IActionResult Index()
        {
          var stringName=  GetCookie();
           var username= User.Identity.Name;
            
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            ViewBag.name = username;
            return View();
        }

        public IActionResult Save()
        {
            

            return View(new CreateUserDto());
        }
        [HttpPost]
        public async Task<IActionResult> Save(CreateUserDto userCreateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _memberApiService.Save(userCreateDto);
                if (result == false)
                {
                    return View(userCreateDto);

                }
                return RedirectToAction("Login", "Member");
            }
            return View(userCreateDto);

        }
        public IActionResult Login( )
        {


            return View(new LoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto userLogin)
        {
            if (ModelState.IsValid)
            {
                var data = await _memberApiService.Login(userLogin);
                if (data == null)
                {
                    
                    return View(userLogin);
                }
                var name = data.Name;

                //var sss = User.Identity.Name;
                SetCookie(data.Id);
                ViewBag.Hosgeldin = $"Hoşgeldiniz {name}";
                return View("Index","Home");
            }
            
            return View(userLogin);
          
           
        }
        [Authorize]
        public IActionResult GetUserInfo()
        {

            var name = User.Identity.Name;
            var sonuc = User.Identity.IsAuthenticated;

            return View();

        }
        
    }

}
