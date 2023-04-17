using cmsGame.Models.Upload;
using System.Collections.Generic;

namespace cmsGame.Service
{
    public interface ICMSService
    {
        public List<UploadAndroidGameModel> ListServiceAndroid();

        public List<UploadJavaGameModel> ListServiceJava();

        public UploadAndroidGameModel CreateServiceAndroid(UploadAndroidGameModel model);
        public UploadJavaGameModel CreateServiceJava(UploadJavaGameModel model);
        public List<OwnerModel> SelectListOwnerServiceAndriod();
        public List<OwnerModel> SelectListOwnerServiceJava();

        public List<GameCategoryModel> SelectListCategoryServiceAndriod();
        public List<GameCategoryModel> SelectListCategoryServiceJava();
    }
}
