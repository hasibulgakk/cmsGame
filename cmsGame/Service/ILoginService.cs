using cmsGame.Models.Account;


namespace cmsGame.Service
{
    public interface ILoginService
    {
        public LoginModel GetLogin(string userName, string password);


    }
}
