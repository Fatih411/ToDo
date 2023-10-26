using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.Dtos.ToDoDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ToDoController : Controller
    {
        ToDoManager toDoManager = new ToDoManager(new EfTodoDal());
        readonly UserManager<User> _userManager;
        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());

        public ToDoController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    
        public IActionResult Index()
        {
            var result = categoryManager.TGetAll();
            ViewBag.v2 = result;
            return View();
        }
        [Route("Todo/DeleteTodo/{id}")]
        public IActionResult DeleteTodo(string id)
        {
            var values = toDoManager.GetById(Guid.Parse(id));
            toDoManager.TDelete(values);
            return RedirectToAction("Index","Home");
        }

        //[Route("Todo/EditToDo/{id}")]
        [HttpGet]
        public IActionResult EditToDo(string id)
        {
            var values = toDoManager.GetById(Guid.Parse(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult EditToDo(UpdateTodo toDo)
        {
            toDoManager.TUpdate(new()
            {
                CategoryId=toDo.CategoryId,
                Name=toDo.Name,
                Description=toDo.Description,
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateTodo createTodo)
        {
            var userId = await _userManager.GetUserAsync(User);
            toDoManager.TInsert(new()
            {
                Id = Guid.NewGuid(),
                CategoryId = createTodo.CategoryId,
                Description = createTodo.Description,
                Name = createTodo.Name,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UserId = userId.Id,
                Status = true
            });
            return RedirectToAction("Index");
        }

       
    }
}
