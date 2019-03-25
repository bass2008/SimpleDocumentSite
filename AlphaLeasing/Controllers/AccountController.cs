using AlphaLeasing.DataAccess.Repository;
using AlphaLeasing.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace AlphaLeasing.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel model)
        {
            var user = _userRepository.GetByLogin(model.Login);

            if (user == null)
            {
                ModelState.AddModelError("Login", "Пользователь с таким логином не найден");
                return View("Login", model);
            }

            if (user.Password != model.Password)
            {
                ModelState.AddModelError("Login", "Неправильный пароль");
                return View("Login", model);
            }

            FormsAuthentication.SetAuthCookie(model.Login, true);

            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}