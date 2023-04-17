using cmsGame.Models.Account;
using cmsGame.Models.Upload;
using Microsoft.EntityFrameworkCore;

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
    }
}
