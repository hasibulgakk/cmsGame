using cmsGame.Data;
using cmsGame.Models.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Service
{
    public class PublishService : IPublishService
    {
        private readonly CMSDbContext cMSDbContext;

        public PublishService(CMSDbContext cMSDbContext )
        {
            this.cMSDbContext = cMSDbContext;
        }
        public List<UploadAndroidGameModel> GetAllPublishGameList()
        {
          return  cMSDbContext.UploadAndroidGameModel.ToList();
        }
    }
}
