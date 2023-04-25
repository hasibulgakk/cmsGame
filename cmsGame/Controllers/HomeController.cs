using cmsGame.Models;
using cmsGame.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ICMSService cMSService;
        private readonly IPublishService publishService;

        public HomeController(ILogger<HomeController> logger,ICMSService cMSService,IPublishService publishService)
		{
			_logger = logger;
            this.cMSService = cMSService;
            this.publishService = publishService;
        }

		public IActionResult Index()
		{
			ViewBag.AndroidCount = cMSService.ListServiceAndroid().Count.ToString();
            ViewBag.JavaCount = cMSService.ListServiceJava().Count.ToString();
			ViewBag.PublishCount= publishService.GetAllPublishGameList().Count.ToString();
            return View();
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
