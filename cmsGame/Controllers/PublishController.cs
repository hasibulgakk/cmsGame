using cmsGame.Models.Upload;
using cmsGame.Service;
using cmsGame.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Controllers
{
    public class PublishController : Controller
    {
        private readonly IPublishService publishService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PublishController(IPublishService publishService,IHttpContextAccessor httpContextAccessor)
        {
            this.publishService = publishService;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Publish()
        {
            var model = await publishService.GetAllPublishGameList();
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
        [HttpGet]
        public async Task<ActionResult> PublishedGameList()
        {
            //await PublishList();
            List<ListPublishViewModel> ListviewModel = new List<ListPublishViewModel>();
            List<PublishedGameListViewModel> listGamemodel = new List<PublishedGameListViewModel>();
            var list = await publishService.GetAllPublishGameList();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(list);
            //viewModel.ListGamePublishViewModel= await publishService.GetAllPublishGameList();
            //foreach (DataRow row in list.Rows)
            for (int i = 0; i < list.Rows.Count; i++)
            {

                ListPublishViewModel viewModel = new ListPublishViewModel();
                viewModel.Game_Title = list.Rows[i]["Game_Title"].ToString();
                viewModel.Publish_Date = Convert.ToDateTime(list.Rows[i]["Publish_Date"]);
                viewModel.Expire = list.Rows[i]["Expire"].ToString();
                viewModel.Category_Code = (int)list.Rows[i]["Category_Code"];
                viewModel.Game_Code = (int)list.Rows[i]["Game_Code"];
                viewModel.Game_Type = list.Rows[i]["Game_Type"].ToString();
                viewModel.Publish_By = list.Rows[i]["Publish_By"].ToString();
                viewModel.Publish_ID = (int)list.Rows[i]["Publish_ID"];
                viewModel.Portal_Code = (int)list.Rows[i]["Portal_Code"];
                ListviewModel.Add(viewModel);
                // var a=viewModel.Game_Code.ToString();
                //DataRow[] rows = list.Select("a = 'this'");
               // string publish_by = httpContextAccessor.HttpContext.Session.GetString("User");

               // var result = await publishService.InsertPublishGameData(viewModel.Game_Code, viewModel.Portal_Code, viewModel.Category_Code, viewModel.Game_Type, DateTime.Now, publish_by);



               // DataTable result1 = await publishService.GetGame(viewModel.Game_Type, viewModel.Portal_Code.ToString());

                //for (int j = i; j < result1.Rows.Count; j++)
                //{
                //    PublishedGameListViewModel model = new PublishedGameListViewModel();
                //    model.Game_Code = (int)result.Rows[j]["Game_Code"];
                //    model.Game_Title = result.Rows[j]["Game_Title"].ToString();
                //    listGamemodel.Add(model);
                  
                //}

            }
            //DataTable result = publishService.GetGame();
            return View(ListviewModel);
        }
        //[HttpPost]
        //public async Task<ActionResult> SaveGameAsync(int code, int portal, int Cat, int subcat, string type)
        //{
        //    Publish();
        //    //Game gm = new Game();
        //    DataTable result;
        //    //if (System.IO.File.Exists(zippath))
        //    //{
        //    //System.IO.File.Delete(zippath);
        //    //}

        //    string publish_by = httpContextAccessor.HttpContext.Session.GetString("User");
        //    if (subcat == 0)
        //    {
        //        result = await publishService.InsertPublishGameData(code, portal, Cat, type, DateTime.Now, publish_by);
        //    }
        //    else
        //    {
        //        result = await publishService.InsertPublishGameData(code, portal, subcat, type, DateTime.Now, publish_by);
        //    }
        //    if (result != null)
        //    {
        //        //List<Game> gmList = gm.GetPortal();
        //        ////return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);

        //        //if (gmList.Count > 0)
        //        //{
        //        //    ViewBag.Portal = new SelectList(gmList, "ContentCode", "ContentTitle");
        //        //    //return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);
        //        //}
        //        //ViewBag.error = "Publish Sucessful";
        //        return View("Publish");
        //    }
        //    else
        //    {
        //        //List<Game> gmList = gm.GetPortal();
        //        ////return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);

        //        //if (gmList.Count > 0)
        //        //{
        //        //    ViewBag.Portal = new SelectList(gmList, "ContentCode", "ContentTitle");
        //        //    //return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);
        //        //}
        //        //ViewBag.error = "Publish Failed";
        //        return null;
        //    }
        //}
    }
}
