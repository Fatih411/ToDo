using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.Dtos.ToDoDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        ToDoManager toDoManager = new ToDoManager(new EfTodoDal());
        readonly UserManager<User> _userManager;
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ToDoController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _userManager.GetUserAsync(User);
            var result = toDoManager.TGetAll().Where(p=>p.Status==true&&p.UserId==userId.Id).ToList();
            return View(result);
        }
       [Route("Todo/DeleteTodo/{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var values = toDoManager.GetById(id);
            toDoManager.TDelete(values);
            return RedirectToAction("Index", "ToDo");
        }
        [Route("Todo/EditToDo/{id}")]
        [HttpGet]
        public IActionResult EditToDo(int id)
        {
            ViewBag.v2 = categoryManager.TGetAll();
            var values = toDoManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> EditToDo(ToDo toDo)
        {
            var userId = await _userManager.GetUserAsync(User);
             toDoManager.TUpdate(new()
            {
                Id = toDo.Id,
                UserId= userId.Id,
                CategoryId = toDo.CategoryId,
                Name=toDo.Name,
                Description=toDo.Description,
                CreateDate=DateTime.Now,
                Status=toDo.Status,
                UpdateDate=DateTime.Now,

            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateTodo createTodo)
        {
            var userId = await _userManager.GetUserAsync(User);
            toDoManager.TInsert(new()
            {
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
        [HttpGet]
        public  IActionResult ToDoAdd()
        {

            ViewBag.v1 = categoryManager.TGetAll();
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> ToDoAdd(ToDo todo)
        {
            var userId = await _userManager.GetUserAsync(User);
            toDoManager.TInsert(new()
            {
                Name = todo.Name,
                CategoryId = todo.CategoryId,
                UserId = userId.Id,
                Description = todo.Description,
                CreateDate = DateTime.Now,
                Status = true,
                UpdateDate = DateTime.Now,
            });
            return RedirectToAction("Index");
        }

    }
}
