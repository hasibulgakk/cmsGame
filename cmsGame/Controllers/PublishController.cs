using cmsGame.Models.Publish;
using cmsGame.Models.Upload;
using cmsGame.Service;
using cmsGame.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           await UploadBillboard();
           List <ListPublishViewModel> listPublish = new List<ListPublishViewModel> ();
            var models = await publishService.GetAllPublishList();
            for (int i = 0; i < models.Rows.Count; i++)
            {
                ListPublishViewModel publish = new ListPublishViewModel();
                publish.Publish_Date = DateTime.Now;
                publish.Publish_By = models.Rows[i]["Publish_By"].ToString();
                publish.Publish_ID= (int)models.Rows[i]["Publish_ID"];   
                publish.Category_Code = (int)models.Rows[i]["Category_Code"];
                publish.Expire = models.Rows[i]["Expire"].ToString();
                publish.Game_Code = (int)models.Rows[i]["Game_Code"];
                publish.Game_Title= models.Rows[i]["Game_Title"].ToString();
                publish.Portal_Code = (int)models.Rows[i]["Portal_Code"];
                publish.Game_Type = models.Rows[i]["Game_Type"].ToString();
                listPublish.Add(publish);
              
            }
            return View(listPublish);

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





        [HttpGet]
        public async Task<ActionResult> UploadBillboard()
        {
          List<GamePortalMasterModel> gm = new List<GamePortalMasterModel>();
           var gmList =await publishService.GetPortal();
            for (int i = 0; i < gmList.Rows.Count; i++)
            {
                GamePortalMasterModel model = new GamePortalMasterModel();
                model.Portal_Code = (int)gmList.Rows[i]["Portal_Code"];
                model.Portal_Name = gmList.Rows[i]["Portal_Name"].ToString();
                gm.Add(model);
            }
            ViewBag.Portal = new SelectList(gm, "Portal_Code", dataTextField: "Portal_Name");
           

           
            return View();
        }


        public async Task<JsonResult> GetPubCat(string Id)
        {
            List<GetPublishCategoryModel> models=new List<GetPublishCategoryModel>();

               var catList =await publishService.GetPubCat(Convert.ToInt32(Id));
           for(int i = 0; i < catList.Rows.Count; i++) {
                GetPublishCategoryModel model = new GetPublishCategoryModel();
                model.Category_Code = (int)catList.Rows[i]["Category_Code"];
                model.Category_Title = catList.Rows[i]["Category_Title"].ToString();
                models.Add(model);
                    }
                //var result = new SelectList(catList, "CategoryCode", "CategoryName");
                //return Json(new { myResult = result }, JsonRequestBehavior.AllowGet);
                return Json(new SelectList(models, "CategoryCode", "CategoryName"));
            
           
        }

        //public JsonResult GetSubCat(string Id)
        //{
        //    Game gm = new Game();

        //    List<Game> catList = gm.GetPublishSubCategory(Id);
        //    if (catList.Count > 0)
        //    {
        //        //var result = new SelectList(catList, "CategoryCode", "CategoryName");
        //        //return Json(new { myResult = result }, JsonRequestBehavior.AllowGet);
        //        return Json(new SelectList(catList, "CategoryCode", "CategoryName"));
        //    }
        //    else
        //    {
        //        return Json(new SelectList(catList, "CategoryCode", "CategoryName"));
        //    }

        //}
    }
}
