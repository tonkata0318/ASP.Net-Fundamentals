using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers
{
    public class NumbersToN : Controller
    {
        private readonly ILogger _logger;

        public NumbersToN(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Limit(int num)
        {
            return View("Limit",num);
        }
    }
}
