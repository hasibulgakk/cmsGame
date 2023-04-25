using cmsGame.Data;
using cmsGame.Models.Upload;
using System.Collections.Generic;
using System.Linq;

namespace cmsGame.Service
{
    public class CMSService : ICMSService
    {

        private readonly CMSDbContext dbContext;

        public CMSService(CMSDbContext dbContext)
        {
       
            this.dbContext = dbContext;
        }
        public UploadAndroidGameModel CreateServiceAndroid(UploadAndroidGameModel model)
        {
            dbContext.UploadAndroidGameModel.Add(model);
            dbContext.SaveChanges();
            return model;
           
        }

        public UploadJavaGameModel CreateServiceJava(UploadJavaGameModel model)
        {
            dbContext.UploadJavaGameModel.Add(model);   
            dbContext.SaveChanges();
            return model;
            
        }

       public List<UploadAndroidGameModel> ListServiceAndroid()
        {
            return dbContext.UploadAndroidGameModel.ToList();
        }

        public List<UploadJavaGameModel> ListServiceJava()
        {
            return dbContext.UploadJavaGameModel.ToList();
        }

        public List<OwnerModel> SelectListOwnerServiceJava()
        {
            return dbContext.OwnerModels.Select(x => new OwnerModel()
            {
                Owner_Code = x.Owner_Code,
                Owner_Name = x.Owner_Name,
            }).ToList();
        }
        public List<OwnerModel> SelectListOwnerServiceAndriod()
        {
            return dbContext.OwnerModels.Select(x => new OwnerModel()
            {
                Owner_Code = x.Owner_Code,
                Owner_Name = x.Owner_Name,
            }).ToList();
        }


        public List<GameCategoryModel> SelectListCategoryServiceJava()
        {
            return dbContext.GameCategoryModels.Select(x => new GameCategoryModel()
            {
                Category_Code = x.Category_Code,
                Category_Title = x.Category_Title,
            }).ToList();
        }
        public List<GameCategoryModel> SelectListCategoryServiceAndriod()
        {
            return dbContext.GameCategoryModels.Select(x => new GameCategoryModel()
            {
                 Category_Code = x.Category_Code,
                Category_Title = x.Category_Title,
            }).ToList();
        }

        public UploadAndroidGameModel EditServiceAndroid(int Game_Code,UploadAndroidGameModel uploadAndroid)
        {
        var model=   dbContext.UploadAndroidGameModel.FirstOrDefault(x => x.Game_Code == Game_Code);
            dbContext.SaveChanges();
            return model;
        }

        public UploadJavaGameModel EditServiceJava(int Game_Code, UploadJavaGameModel uploadJava)
        {
            var model = dbContext.UploadJavaGameModel.FirstOrDefault(x => x.Game_Code == Game_Code);
            dbContext.SaveChanges();
            return model;
        }
    }
}
