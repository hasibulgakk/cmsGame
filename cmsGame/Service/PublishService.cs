using cmsGame.Data;
using cmsGame.Models.Publish;
using cmsGame.Models.Upload;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cmsGame.Service
{
    public class PublishService : IPublishService
    {
        private readonly CMSDbContext cMSDbContext;

        public PublishService(CMSDbContext cMSDbContext)
        {
            this.cMSDbContext = cMSDbContext;
        }
        //public async Task<List<GamePublishModel>> GetAllPublishGameList()
        //{
        //  return await cMSDbContext.gamePublishModels.ToListAsync();
        //}

        public async Task<DataTable> GetAllPublishGameList()
        {
            DataTable dt=new DataTable();
            SqlConnection dbConnection = (SqlConnection)cMSDbContext.Database.GetDbConnection();

            using (SqlDataAdapter da = new SqlDataAdapter("spPublishGameList", dbConnection))
            {
               da.Fill(dt);
            
                return dt;
                    }
        }
    }
}
