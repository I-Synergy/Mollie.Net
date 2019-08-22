using Microsoft.AspNetCore.Mvc;

namespace Mollie.Sample.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}