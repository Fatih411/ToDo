﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var result = categoryManager.TGetAll();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CreateCategory model)
        {
            categoryManager.TInsert(new()
            {
                Name = model.Name,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            });
            return RedirectToAction("Index");
        }
    }
}
