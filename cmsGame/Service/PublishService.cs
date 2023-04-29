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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace cmsGame.Service
{
    public class PublishService : IPublishService
    {
        private readonly CMSDbContext cMSDbContext;

        public PublishService(CMSDbContext cMSDbContext)
        {
            this.cMSDbContext = cMSDbContext;
        }
        public async Task<DataTable> GetAllPublishList()
        {
            
           DataTable dt = new DataTable();
            SqlConnection dbConnection = (SqlConnection)cMSDbContext.Database.GetDbConnection();

            using (SqlDataAdapter da = new SqlDataAdapter("spPublishGameList", dbConnection))
            {
                da.Fill(dt);

                return dt;
            }
        }

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
     public async Task<DataTable> GetPubCat(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection dbConnection = (SqlConnection)cMSDbContext.Database.GetDbConnection();

            using (var cmd = new SqlCommand("exec spGetPublishCategory" +" "+ id.ToString(), dbConnection))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
        }

        public async Task<DataTable> GetSubCat(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection dbConnection = (SqlConnection)cMSDbContext.Database.GetDbConnection();

            using (var cmd = new SqlCommand("exec spGetPublishSubCategory" + " " + id.ToString(), dbConnection))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
        }

        public async Task<DataTable> GetPortal()
        {
            DataTable dt = new DataTable();
            SqlConnection dbConnection = (SqlConnection)cMSDbContext.Database.GetDbConnection();

            using (SqlDataAdapter da = new SqlDataAdapter("spGetPortal", dbConnection))
            {
                //  SqlCommand  sqlCommand=new SqlCommand();
                //var dr = sqlCommand.ExecuteReader();
                
                //sqlCommand.CommandText = "exec spGetPortal";
                //SqlParameter sp = new SqlParameter();
                //sp.ParameterName = "@id";
             
                //sqlCommand.Parameters.Add(sp);
                da.Fill(dt);

                return dt;
            }

        }
            //public async Task<List<Game>> GetGame(string Type, string Portal)
            //{
            //    DataSet ds = db.GetDataSet("spGetAllGameByType '" + Type + "', '" + Portal + "'", "GPCMS");
            //    if (ds != null)
            //    {
            //        Game gm = new Game();
            //        List<Game> gmList = new List<Game>();
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            gm = new Game();
            //            gm.ContentCode = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            //            gm.ContentTitle = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //            gm.PreviewURL = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            //            gm.OwnerCode = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            //            gm.CategoryName = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            //            gm.GamePrice = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            //            gm.PhysicalFile = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            //            gmList.Add(gm);
            //        }
            //        return gmList;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}


        }
}
