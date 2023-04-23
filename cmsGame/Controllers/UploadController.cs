using cmsGame.Data;
using cmsGame.Models.Upload;
using cmsGame.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace cmsGame.Controllers
{
    public class UploadController : Controller
    {
        private readonly ICMSService cMSService;
        private readonly IWebHostEnvironment environment;

        public UploadController(ICMSService cMSService, IWebHostEnvironment environment)
        {
            this.cMSService = cMSService;
            this.environment = environment;
        }
        // GET: UploadController
        public ActionResult Index()
        {
            return View();
        }

        // Details List Android
        public ActionResult DetailsAndroidGame()
        {
            UploadFileAndroidGame();
            var model = cMSService.ListServiceAndroid().OrderByDescending(x=>x.Game_Code).ToList();
            return View(model);

        }

        // Details List Java
        public ActionResult DetailsJavaGame()
        {
            UploadFileJavaGame();
            var model = cMSService.ListServiceJava().ToList();
            return View(model);
        }


        // GET: UploadController/Create
        public ActionResult CreateForAndroid()
        {
            return View();
        }

        // POST: UploadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForAndroid(IFormCollection collection)
        {
            try
            {

                UploadAndroidGameModel upload = new UploadAndroidGameModel();
                upload.Game_Title = collection["Game_Title"];
                upload.Preview_URL = collection["Preview_URL"];
                upload.Physical_Location = collection["Physical_Location"];
                upload.Owner_Code = Convert.ToInt32(collection["Owner_Code"]);
                upload.Game_Type_Code = Convert.ToInt32(collection["Game_Type_Code"]);
                upload.Game_Price = collection["Game_Price"];
                upload.Android_Version = collection["Android_Version"];
                upload.Description = collection["Description"];
                upload.Expire = collection["Expire"];
                upload.Upload_Date = DateTime.Parse(collection["Upload_Date"]);
                upload.Upload_By = collection["Upload_By"];
                upload.Banner_Url = collection["Banner_Url"];
                upload.Install = collection["Install"];
                upload.CurrentVersion = collection["CurrentVersion"];
                upload.Size = collection["Size"];
                upload.InstallK = collection["InstallK"];

                cMSService.CreateServiceAndroid(upload);
                return RedirectToAction("DetailsAndroidGame", "Upload");
            }
            catch
            {
                return View();
            }
        }


        // GET: UploadController/Create
        public ActionResult CreateForJava()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForJava(IFormCollection collection)
        {
            try
            {

                UploadJavaGameModel upload = new UploadJavaGameModel();
                upload.Game_Title = collection["Game_Title"];
                upload.Preview_URL = collection["Preview_URL"];
                
                upload.Game_Owner_Code= Convert.ToInt32(collection["Owner_Code"]);
                upload.Game_Type_Code = Convert.ToInt32(collection["Game_Type_Code"]);
                upload.Game_Price = collection["Game_Price"];
               
                upload.Description = collection["Description"];
                upload.Expire = collection["Expire"];
                upload.Upload_Date = DateTime.Parse(collection["Upload_Date"]);
                upload.Upload_By = collection["Upload_By"]; 
                upload.Ismapped = collection["Ismapped"];
                upload.Banner_Url = collection["Banner_Url"];
              

                cMSService.CreateServiceJava(upload);
                return RedirectToAction("DetailsJavaGame", "Upload");
            }
            catch
            {
                return View();
            }
        }


        // GET: UploadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult UploadFileAndroidGame()
        {
            OwnerModel ownerModel = new OwnerModel();
            List<OwnerModel> ownerModelsList = cMSService.SelectListOwnerServiceAndriod();
            if (ownerModelsList.Count > 0)
            {
                ViewBag.Owner = new SelectList(ownerModelsList, "Owner_Code", "Owner_Name");
            }
            GameCategoryModel categryModel = new GameCategoryModel();
            List<GameCategoryModel> catList = cMSService.SelectListCategoryServiceAndriod();
            if (catList.Count > 0)
            {
                ViewBag.Category = new SelectList(catList, "Category_Code", "Category_Title");
            }

            return View();
        }

        public ActionResult UploadFileJavaGame()
        {
            OwnerModel ownerModel = new OwnerModel();
            List<OwnerModel> ownerModelsList = cMSService.SelectListOwnerServiceAndriod();
            if (ownerModelsList.Count > 0)
            {
                ViewBag.Owner = new SelectList(ownerModelsList, "Owner_Code", "Owner_Name");
            }
            GameCategoryModel categryModel = new GameCategoryModel();
            List<GameCategoryModel> catList = cMSService.SelectListCategoryServiceAndriod();
            if (catList.Count > 0)
            {
                ViewBag.Category = new SelectList(catList, "Category_Code", "Category_Title");
            }

            return View();
        }

        [HttpPost]
        public ActionResult InsertGameAndroid(IFormFile CsvFile, IFormCollection formCollection)
        {
            UploadAndroidGameModel gameModel = new UploadAndroidGameModel();
           
            List<OwnerModel> ownerModelsList = cMSService.SelectListOwnerServiceAndriod();
            if (ownerModelsList.Count > 0)
            {
                ViewBag.Owner = new SelectList(ownerModelsList, "Owner_Code", "Owner_Name");
            }
           
            List<GameCategoryModel> catList = cMSService.SelectListCategoryServiceAndriod();
            if (catList.Count > 0)
            {
                ViewBag.Category = new SelectList(catList, "Category_Code", "Category_Title");
            }

            try
            {
                if (!string.IsNullOrEmpty(formCollection["ddlOwner"]))
                {
                    if (!string.IsNullOrEmpty(formCollection["ddlCategory"]))
                    {

                        if (CsvFile.FileName.Trim().ToLower().Contains(".csv"))
                        {
                            StreamReader reader = new StreamReader(CsvFile.OpenReadStream());

                            //var uploadsPath = Path.Combine(environment.ContentRootPath, "Content");
                            var uploadsPath = Path.Combine(environment.WebRootPath, "uploads");
                            string filePath = Path.Combine(uploadsPath, CsvFile.FileName);


                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                CsvFile.CopyToAsync(fileStream);
                            }

                            DataTable dt = ProcessCSV(filePath);
                          
                            List<UploadAndroidGameModel> listGame = new List<UploadAndroidGameModel>();


                            foreach (DataRow dr in dt.Rows)
                            {
                                gameModel.Game_Title = dr["Column1"].ToString();
                                gameModel.Preview_URL = dr["Column2"].ToString();
                                gameModel.Owner_Code = Convert.ToInt32(formCollection["ddlOwner"]);
                                gameModel.Game_Type_Code = Convert.ToInt32(formCollection["ddlCategory"]);
                                gameModel.Upload_Date = DateTime.Now;
                                gameModel.Physical_Location = dr["Column3"].ToString();
                                gameModel.Game_Price = dr["Column6"].ToString();
                                //gameModel.Android_Version = dr["Column7"].ToString();
                                gameModel.Expire = dr["Column9"].ToString();
                                cMSService.CreateServiceAndroid(gameModel);
                                listGame.Add(gameModel);

                                //if (!string.IsNullOrEmpty(gameModel.Game_Price))
                                //{
                                //    gameModel.InsertGraphicContent(gameModel);
                                //}
                            }
                            reader.Close();
                            reader.Dispose();
                              var model = cMSService.ListServiceAndroid().ToList();
                           
                                System.IO.File.Delete(filePath);

                            return View("DetailsAndroidGame", model);
                        }
                        else
                        {
                            ViewBag.Error = "File Type Is Incorrect. Please Provide CSV File.";
                            return View("DetailsAndroidGame");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Please Select Category.";
                        return View("DetailsAndroidGame");
                    }
                }
                else
                {
                    ViewBag.Error = "Please Select Category.";
                    return View("DetailsAndroidGame");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "File Type Is Incorrect. Please Provide CSV File. " + ex.Message;
                return View("DetailsAndroidGame");
            }
        }

        [HttpPost]
        public ActionResult InsertGameJava(IFormFile CsvFile, IFormCollection formCollection)
        {
            UploadJavaGameModel gameModel = new UploadJavaGameModel();
            
            List<OwnerModel> ownerModelsList = cMSService.SelectListOwnerServiceJava();
            if (ownerModelsList.Count > 0)
            {
                ViewBag.Owner = new SelectList(ownerModelsList, "Owner_Code", "Owner_Name");
            }
          
            List<GameCategoryModel> catList = cMSService.SelectListCategoryServiceJava();
            if (catList.Count > 0)
            {
                ViewBag.Category = new SelectList(catList, "Category_Code", "Category_Title");
            }

            try
            {
                if (!string.IsNullOrEmpty(formCollection["ddlOwner"]))
                {
                    if (!string.IsNullOrEmpty(formCollection["ddlCategory"]))
                    {

                        if (CsvFile.FileName.Trim().ToLower().Contains(".csv"))
                        {
                            StreamReader reader = new StreamReader(CsvFile.OpenReadStream());

                            var uploadsPath = Path.Combine(environment.WebRootPath, "uploads");
                            //var uploadsPath = Path.Combine(environment.ContentRootPath, "Content");
                            string filePath = Path.Combine(uploadsPath, CsvFile.FileName);
                
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                CsvFile.CopyToAsync(fileStream);
                            }

                            DataTable dt = ProcessCSV(filePath);
                           List<UploadJavaGameModel> listGame = new List<UploadJavaGameModel>();

                        

                            foreach (DataRow dr in dt.Rows)
                            {
                                gameModel.Game_Title = dr["Column1"].ToString();
                                gameModel.Preview_URL = dr["Column2"].ToString();
                                gameModel.Game_Owner_Code = Convert.ToInt32(formCollection["ddlOwner"]);
                                gameModel.Game_Type_Code = Convert.ToInt32(formCollection["ddlCategory"]);
                                gameModel.Upload_Date = DateTime.Now;
                                gameModel.Game_Price = dr["Column6"].ToString();
                                gameModel.Expire = dr["Column9"].ToString();
                                cMSService.CreateServiceJava(gameModel);
                               listGame.Add(gameModel);

                                //if (!string.IsNullOrEmpty(gameModel.Game_Price))
                                //{
                                //    gameModel.InsertGraphicContent(gameModel);
                                //}
                            }
                            reader.Close();
                            reader.Dispose();
                            var model = cMSService.ListServiceJava().ToList();
                            System.IO.File.SetAttributes(uploadsPath, FileAttributes.Normal);
                            System.IO.File.Delete(filePath);

                            return View("DetailsJavaGame", model);
                        }
                        else
                        {
                            ViewBag.Error = "File Type Is Incorrect. Please Provide CSV File.";
                            return View("DetailsJavaGame");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Please Select Category.";
                        return View("DetailsJavaGame");
                    }
                }
                else
                {
                    ViewBag.Error = "Please Select Category.";
                    return View("DetailsAndroidGame");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "File Type Is Incorrect. Please Provide CSV File. " + ex.Message;
                return View("DetailsAndroidGame");
            }
        }
        public DataTable ProcessCSV(string fileName)
        {
            //Set up our variables 
            string Feedback = string.Empty;
            string line = string.Empty;
            string[] strArray;
            DataTable dt = new DataTable();
            DataRow row;

            // work out where we should split on comma, but not in a sentance
            Regex r = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            //Set the filename in to our stream
            StreamReader sr = new StreamReader(fileName);

            //Read the first line and split the string at , with our regular express in to an array
            line = sr.ReadLine();
            strArray = r.Split(line);

            //For each item in the new split array, dynamically builds our Data columns. Save us having to worry about it.
            Array.ForEach(strArray, s => dt.Columns.Add(new DataColumn()));


            //Read each line in the CVS file until it's empty
            while ((line = sr.ReadLine()) != null)
            {
                row = dt.NewRow();

                //add our current value to our data row
                row.ItemArray = r.Split(line);
                dt.Rows.Add(row);
            }

            //Tidy Streameader up
            sr.Dispose();

            //return a the new DataTable
            return dt;
        }
        
    }
}
