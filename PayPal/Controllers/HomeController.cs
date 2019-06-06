using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PayPal.Models;
using PayPal.Server;

namespace PayPal.Controllers
{
    public class HomeController : Controller
    {
        private readonly PayPalOptions _options;

        public HomeController(IOptionsMonitor<PayPalOptions> optionsMonitor)
        {
            _options = optionsMonitor.CurrentValue;
        }

        public IActionResult Index()
        {
            return View(model: _options.ClientId);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
