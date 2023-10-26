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
       
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            

        }

        [HttpGet]
        public IActionResult Index()
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