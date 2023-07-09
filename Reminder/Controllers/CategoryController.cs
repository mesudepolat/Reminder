using Microsoft.AspNetCore.Mvc;
using Reminder.Service.Core;
using Reminder.Service.Models;

namespace Reminder.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var models = _categoryService.GetAll();
            return View(models);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var model = _categoryService.GetById(id);
            return View(model);
        }
        public IActionResult Save(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Save(model);
                TempData["succes"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Hata oluştu";
            return View("Create", model);
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                _categoryService.Delete(Id);

            }
            catch (Exception)
            {
                TempData["error"] = "Bir Hata ile Karşılaşıldı";
                return RedirectToAction("Index");

            }
            TempData["succes"] = "Kayıt Silindi";
            return RedirectToAction("Index");

        }
    }
}
