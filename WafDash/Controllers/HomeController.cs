using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WafDash.Models;
using WafDash.Services;

namespace WafDash.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IDataService dataService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            var t = _dataService.GetLogs();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}