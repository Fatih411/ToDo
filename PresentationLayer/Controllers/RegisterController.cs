using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DTOLayer.Dtos.UserDtos;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        readonly UserManager<User> _userManager;

        public RegisterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegister _user)
        {
            if(ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = _user.UserName,
                    Email = _user.Email,
                };
                var result=await _userManager.CreateAsync(user,_user.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
