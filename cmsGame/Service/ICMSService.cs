using cmsGame.Models.Upload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmsGame.Service
{
    public interface ICMSService
    {
        public Task<List<UploadAndroidGameModel>> ListServiceAndroid();
   
        public Task<List<UploadJavaGameModel>> ListServiceJava();

        public Task<UploadAndroidGameModel> CreateServiceAndroid(UploadAndroidGameModel model);
        public Task<UploadJavaGameModel> CreateServiceJava(UploadJavaGameModel model);
        public Task<List<OwnerModel>> SelectListOwnerServiceAndriod();
        public Task<List<OwnerModel>> SelectListOwnerServiceJava();

        public Task<List<GameCategoryModel>> SelectListCategoryServiceAndriod();
        public Task<List<GameCategoryModel>> SelectListCategoryServiceJava();

        public Task<UploadAndroidGameModel> EditServiceAndroid(int Game_Code, UploadAndroidGameModel uploadAndroid);
        public Task<UploadAndroidGameModel> EditServiceAndroidGame(int Game_Code);
        public Task<UploadJavaGameModel> EditServiceJavaGame(int Game_Code);
        public Task<UploadJavaGameModel> EditServiceJava(int Game_Code, UploadJavaGameModel uploadJava);
    }
}
