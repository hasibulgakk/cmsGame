using cmsGame.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using cmsGame.Service;

namespace cmsGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService loginService;

        public AccountController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewData["error"] = TempData["error"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(LoginModel login)
        {
            string usrId = login.UserName;
            string passw = login.Password;
            loginService.GetLogin(usrId, passw);

            if (loginService.GetLogin(usrId, passw)!=null)
            {
              
                HttpContext.Session.SetString("User", usrId);
                //Session["User"] = usrId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Login Failed.";
            }
            //return Json(users, JsonRequestBehavior.AllowGet);
            //return View();

            return RedirectToAction("Login", "Account");

        }
        public ActionResult Logout()
        {
          
            return RedirectToAction("Login", "Account");
        }
    }
}
