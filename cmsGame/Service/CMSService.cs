using cmsGame.Data;
using cmsGame.Models.Upload;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Service
{
    public class CMSService : ICMSService
    {

        private readonly CMSDbContext dbContext;

        public CMSService(CMSDbContext dbContext)
        {
       
            this.dbContext = dbContext;
        }
        public async Task<UploadAndroidGameModel> CreateServiceAndroid(UploadAndroidGameModel model)
        {
            dbContext.UploadAndroidGameModel.Add(model);
            dbContext.SaveChanges();
            return model;
           
        }

        public async Task<UploadJavaGameModel> CreateServiceJava(UploadJavaGameModel model)
        {
            dbContext.UploadJavaGameModel.Add(model);   
            dbContext.SaveChanges();
            return model;
            
        }

       public async Task<List<UploadAndroidGameModel>> ListServiceAndroid()
        {
            try
            {
                return await dbContext.UploadAndroidGameModel.OrderByDescending(i => i.Upload_Date).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        
        public async Task<List<UploadJavaGameModel>> ListServiceJava()
        {
            return await dbContext.UploadJavaGameModel.OrderByDescending(i => i.Upload_Date).ToListAsync();
        }

        public async Task<List<OwnerModel>> SelectListOwnerServiceJava()
        {
            return await dbContext.OwnerModels.Select(x => new OwnerModel()
            {
                Owner_Code = x.Owner_Code,
                Owner_Name = x.Owner_Name,
            }).ToListAsync();
        }
        public async Task<List<OwnerModel>> SelectListOwnerServiceAndriod()
        {
            return await dbContext.OwnerModels.Select(x => new OwnerModel()
            {
                Owner_Code = x.Owner_Code,
                Owner_Name = x.Owner_Name,
            }).ToListAsync();
        }


        public async Task<List<GameCategoryModel>> SelectListCategoryServiceJava()
        {
            return await dbContext.GameCategoryModels.Select(x => new GameCategoryModel()
            {
                Category_Code = x.Category_Code,
                Category_Title = x.Category_Title,
            }).ToListAsync();
        }
        public async Task<List<GameCategoryModel>> SelectListCategoryServiceAndriod()
        {
            var a= await dbContext.GameCategoryModels.Select(x => new GameCategoryModel()
            {
                Category_Code = x.Category_Code,
                Category_Title = x.Category_Title,
            }).ToListAsync();
            return  a;
            //return await dbContext.GameCategoryModels.Select(x => new GameCategoryModel()
            //{
            //     Category_Code = x.Category_Code,
            //    Category_Title = x.Category_Title,
            //}).ToListAsync();
        }

        public async Task<UploadAndroidGameModel> EditServiceAndroid(int Game_Code,UploadAndroidGameModel uploadAndroid)
        {
        var model= await  dbContext.UploadAndroidGameModel.FirstOrDefaultAsync(x => x.Game_Code == Game_Code);
            dbContext.SaveChanges();
            return model;
        }
        public async Task<UploadAndroidGameModel> EditServiceAndroidGame(int Game_Code)
        {

            return await dbContext.UploadAndroidGameModel.OrderByDescending(i => i.Upload_Date).FirstOrDefaultAsync(x => x.Game_Code == Convert.ToInt32(Game_Code));

        }

        public async Task<UploadJavaGameModel> EditServiceJavaGame(int Game_Code)
        {

            return await dbContext.UploadJavaGameModel.OrderByDescending(i => i.Upload_Date).FirstOrDefaultAsync(x => x.Game_Code == Convert.ToInt32(Game_Code));

        }
        public async Task<UploadJavaGameModel> EditServiceJava(int Game_Code, UploadJavaGameModel uploadJava)
        {
            var model =await dbContext.UploadJavaGameModel.FirstOrDefaultAsync(x => x.Game_Code == Game_Code);
            dbContext.SaveChanges();
            return model;
        }
    }
}
