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

using System.Threading.Tasks;

namespace cmsGame.Controllers
{
    public class PublishController : Controller
    {
        private readonly IPublishService publishService;
        private readonly IHttpContextAccessor httpContextAccessor;
        ListPublishViewModel viewModel = new ListPublishViewModel();
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
          var Publish_ID =  HttpContext.Request.Query["Publish_ID"].ToString()!="" ? HttpContext.Request.Query["Publish_ID"].ToString():"1";
            await GetPublish( Publish_ID);
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
       public async Task<ActionResult> GetPublish(string Publish_ID)
        {
      
            var list = await publishService.GetPublishGameListByPublishID(Publish_ID);
      
            for (int i = 0; i < list.Rows.Count; i++) {
                viewModel.Game_Title = list.Rows[i]["Game_Title"].ToString();
                viewModel.Publish_Date = Convert.ToDateTime(list.Rows[i]["Publish_Date"]);
                viewModel.Expire = list.Rows[i]["Expire"].ToString();
                viewModel.Category_Code = (int)list.Rows[i]["Category_Code"];
                viewModel.Game_Code = (int)list.Rows[i]["Game_Code"];
                viewModel.Game_Type = list.Rows[i]["Game_Type"].ToString();
                viewModel.Publish_By = list.Rows[i]["Publish_By"].ToString();
                viewModel.Publish_ID = (int)list.Rows[i]["Publish_ID"];
                viewModel.Portal_Code = (int)list.Rows[i]["Portal_Code"];
           
            }
            await SaveGameAsync();
            return View();
        }

     [HttpGet]
        public async Task<ActionResult> SaveGameAsync()
        {        
        DataTable result;
            
            int  Cat = viewModel.Category_Code;
           int  code = viewModel.Game_Code ;
           string type = viewModel.Game_Type ;

           int portal = viewModel.Portal_Code ;
            string publish_by = httpContextAccessor.HttpContext.Session.GetString("User");
            //if (subcat == 0)
            //{
                result = await publishService.InsertPublishGameData(code, portal, Cat, type, publish_by);
            //}
            //else
            //{
            //    result = await publishService.InsertPublishGameData(code, portal, subcat, type, DateTime.Now, publish_by);
            //}
            if (result != null)
           {
                //List<Game> gmList = gm.GetPortal();
               // return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);

                //if (gmList.Count > 0)
                //{
                //    ViewBag.Portal = new SelectList(gmList, "ContentCode", "ContentTitle");
                //    //return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);
                //}
                //ViewBag.error = "Publish Sucessful";
                return View("PublishedGameList");
            }
            else
            {
                //List<Game> gmList = gm.GetPortal();
               // return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);

                //if (gmList.Count > 0)
                //{
                //    ViewBag.Portal = new SelectList(gmList, "ContentCode", "ContentTitle");
                //    //return Json(new { myResult = gmList }, JsonRequestBehavior.AllowGet);
                //}
                //ViewBag.error = "Publish Failed";
                return null;
            }
        }





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
                return Json(new SelectList(models, "Category_Code", "Category_Title"));
            
           
        }

        public async Task<JsonResult> GetSubCat(string Id)
        {
            List<GetPublishCategoryModel> models = new List<GetPublishCategoryModel>();

            var catList = await publishService.GetSubCat(Convert.ToInt32(Id));
           for(int i = 0; i<catList.Rows.Count; i++) {
                GetPublishCategoryModel model = new GetPublishCategoryModel();
        model.Category_Code = (int) catList.Rows[i]["Category_Code"];
        model.Category_Title = catList.Rows[i]["Category_Title"].ToString();
        models.Add(model);
                    }
                //var result = new SelectList(catList, "CategoryCode", "CategoryName");
                //return Json(new { myResult = result }, JsonRequestBehavior.AllowGet);
                return Json(new SelectList(models, "Category_Code", "Category_Title"));

        }


        [HttpPost]
        public async Task<JsonResult>  GetAllGameByType(string type, string portal)
        {
            List<PublishedGameListViewModel> publishedGameListModel = new List<PublishedGameListViewModel>();
              var model =await publishService.GetAllGameByType(type,portal);
           // return Json(new {myResult=model});
           for(int i = 0; i < model.Rows.Count; i++)
            {
                PublishedGameListViewModel publishedGameModel = new PublishedGameListViewModel();
                publishedGameModel.Game_Title = model.Rows[i]["Game_Title"].ToString();
                publishedGameModel.Game_Code = (int)model.Rows[i]["Game_Code"];
                publishedGameModel.Game_Price = model.Rows[i]["Game_Price"].ToString();
                publishedGameModel.Preview_URL = model.Rows[i]["Preview_URL"].ToString();
                publishedGameModel.Owner_Name = model.Rows[i]["Owner_Name"].ToString();
                publishedGameModel.GType_Name = model.Rows[i]["GType_Name"].ToString();
                publishedGameModel.Physical_Location = model.Rows[i]["Physical_Location"].ToString();
                publishedGameListModel.Add(publishedGameModel);

            }

            return Json(model);
        }


    }
}
