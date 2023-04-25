using cmsGame.Models.Upload;
using cmsGame.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Controllers
{
    public class PublishController : Controller
    {
        private readonly IPublishService publishService;

        public PublishController(IPublishService publishService)
        {
            this.publishService = publishService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Publish()
        {
          var model=  publishService.GetAllPublishGameList().ToList();
            return View(model);

        }

        [HttpPost]
        public string Publish(string Type)
        {
            return Type;
        }

        public ActionResult CreatePublish()
        {
            return View();
        }
    }
}
