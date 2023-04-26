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
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Publish()
        {
          var model= await publishService.GetAllPublishGameList();
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
