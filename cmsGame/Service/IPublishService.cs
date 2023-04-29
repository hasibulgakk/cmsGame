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
        public Task<DataTable> GetPubCat(int id);
        public  Task<DataTable> GetPortal();
        public  Task<DataTable> GetSubCat(int id);
        public Task<DataTable> GetPublishGameListByPublishID(string Publish_ID);
        public  Task<DataTable> InsertPublishGameData(int code, int portal, int Cat, string type, string publishBy);

        public  Task<DataTable> GetAllGameByType(string type, string portal);


    }
}
