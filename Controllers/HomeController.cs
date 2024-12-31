using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghost.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}
