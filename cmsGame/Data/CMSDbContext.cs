using cmsGame.Models.Account;
using cmsGame.Models.Publish;
using cmsGame.Models.Upload;
using Microsoft.EntityFrameworkCore;
using cmsGame.ViewModel;

namespace cmsGame.Data
{
    public class CMSDbContext:DbContext
    {
        public CMSDbContext(DbContextOptions options):base(options) {
        
        }
        public DbSet<UploadAndroidGameModel> UploadAndroidGameModel { get; set; }
        
         public DbSet<UploadJavaGameModel> UploadJavaGameModel { get; set; }
        public DbSet<OwnerModel> OwnerModels { get; set; }
        public  DbSet<GameCategoryModel> GameCategoryModels { get; set; }
      
        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<GamePublishModel>  gamePublishModels { get; set; }
        public DbSet<cmsGame.ViewModel.ListPublishViewModel> ListPublishViewModel { get; set; }
        public DbSet<cmsGame.ViewModel.PublishedGameListViewModel> PublishedGameListViewModel { get; set; }
    }
}
