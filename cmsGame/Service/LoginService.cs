using cmsGame.Data;
using cmsGame.Models.Account;
using cmsGame.Models.Upload;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace cmsGame.Service
{
    public class LoginService:ILoginService
    {
       
        private readonly ApplicationDbContext dbContext;

        public LoginService(ApplicationDbContext dbContext)
        {
            
            this.dbContext = dbContext;
        }
        public LoginModel GetLogin(string userName,string password)
        {
            return dbContext.LoginModels.FirstOrDefault(x=>x.UserName==userName && x.Password==password);
        }

        
    }
}
