using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reminder.Service.Core;
using Reminder.Service.Models;
using System.Net.WebSockets;

namespace Reminder.Controllers
{
    public class LoginController : Controller
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        public SessionInfo UserSession
        {
            get
            {
                var value = HttpContext.Session.GetString("UserSeesionInfo");
                return value == null ? default(SessionInfo) : JsonConvert.DeserializeObject<SessionInfo>(value);
            }
            set
            {
                JsonSerializerSettings jss = new JsonSerializerSettings();
                var jsonString = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString("UserSessionInfo", jsonString);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(LoginViewModel viewModel)
        {
            var user = _loginService.CheckUser(viewModel);
            if (user == null)
            {
                TempData["error"] = "Şifre veya email hatalı";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["success"] = "Giriş Başarılı";
            }
            UserSession = new SessionInfo
            {
                UserId = user.Id,
                UserName = user.Name,
            };
            return RedirectToAction("Index", "Activity");
        }
    }
}

