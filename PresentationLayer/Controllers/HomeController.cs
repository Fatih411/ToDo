using BusinessLayer.Abstract;
using DTOLayer.Dtos.UserDtos;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;
using DataAccessLayer.Repositories;
using DataAccessLayer.Abstract;
using DTOLayer.Dtos.CategoryDtos;
using DataAccessLayer.EntityFramework;
using DTOLayer.Dtos.ToDoDtos;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ToDoManager toDoManager = new ToDoManager(new EfTodoDal());
        readonly UserManager<User> _userManager;
       
        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.UserName;

            var result = toDoManager.TGetAll();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> ToDoAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ToDoAdd(CreateTodo createTodo)
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}