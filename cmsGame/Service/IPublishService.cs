using cmsGame.Models.Publish;
using cmsGame.Models.Upload;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Service
{
    public interface IPublishService
    {
       public Task<DataTable> GetAllPublishList();
        public  Task<DataTable> GetAllPublishGameList();
    }
}
