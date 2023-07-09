using Microsoft.AspNetCore.Mvc;
using Reminder.Service.Data;
using Reminder.Service.Core;
using Reminder.Service.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Reminder.Controllers
{
    public class ActivityController : ControllerBase
    {
        private readonly ActivityService _activityService;

        public ActivityController(ActivityService activityService)
        {
            _activityService = activityService;
        }

        public IActionResult Index()
        {
            var models = _activityService.GetAll();
            return View(models);
        }
        public IActionResult Create()
        {
            var viewModel = _activityService.GetCreateViewModel();
            return View(viewModel);
        }
        public IActionResult Edit(int Id)
        {
            var model = _activityService.GetEditViewModel(Id);

            return View(model);
        }
        public IActionResult Save(ActivityDTO viewmodel)
        {
            if (ModelState.IsValid)
            {
                _activityService.Save(viewmodel);
                TempData["succes"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Bilgiler Kaydedilmedi";

            return View("Create", viewmodel);
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                _activityService.Delete(Id);

            }
            catch (Exception ex)
            {
                TempData["error"] = "Bir Hata ile Karşılaşıldı";
                return RedirectToAction("Index");

            }
            TempData["succes"] = "Kayıt Silindi";
            return RedirectToAction("Index");

        }
    }
}

