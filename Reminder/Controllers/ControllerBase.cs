using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Reminder.Service.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Reminder.Controllers
{
    public class ControllerBase : Controller
    {

        public SessionInfo CurrentSession
        {
            get
            {
                var value = HttpContext.Session.GetString("UserSeesionInfo");
                return value == null ? default(SessionInfo) : JsonConvert.DeserializeObject<SessionInfo>(value);
            }
            set
            {
                //JsonSerializerSettings jss = new JsonSerializerSettings();
                //var jsonString = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString("UserSessionInfo", JsonConvert.SerializeObject(value));
            }
        }
        public bool IsSessionAlive
        {
            get
            {
                return CurrentSession != null;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsSessionAlive == true)
            {
                filterContext.Result = RedirectToLoginPage();
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        protected IActionResult RedirectToLoginPage(string redirectAction = "Index")
        {
            return RedirectToAction("Index", "Login", new { redirectAction = redirectAction });
        }
    }
}

