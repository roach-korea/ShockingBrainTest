using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Ghost.Controllers {
    public class TestController : Controller {
        private static string Code = "2733";

        public IActionResult Index(string? code) {
            if (code != Code)
                return Content("Code is incorrect");

            ViewData["Code"] = code;

            return View();
        }

        public IActionResult Question(int? id, string? code) {
            if (code != Code)
                return Content("Code is incorrect");

            if (code != null)
                ViewData["Code"] = code;

            if (id.HasValue)
                return View($"Question{id.Value}");

            return View();
        }
    }
}
