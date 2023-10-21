using GameChanger.Managers;
using GameChanger.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameChanger.Controllers
{
    public class UserAccountController : Controller
    {
        private MailValidatorManager _mailValidatorManager;
        private UserAccountManager _userAccountManager;

        public UserAccountController()
        {
            _userAccountManager = new UserAccountManager();
            _mailValidatorManager = new MailValidatorManager();
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            UserAccount model = new UserAccount();
            var provinces = _userAccountManager.GetProvinces();
            ViewBag.Provinces = provinces; // Sirve para sumar una lista u accesorios necesarios para una vista que no entran en el modelo original
            return View("NuevoUsuario", model);
        }

        [HttpPost]
        public IActionResult New(UserAccount data)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(data.UserName))
            {
                ModelState.AddModelError("UserName", "El nombre de usuario no es correcto");
                valid = false;
            }
            else
            {
                List<UserAccount> UserAccountList = new List<UserAccount>();
                UserAccountList = _userAccountManager.UserAccountGetByUserName(data);

                if (UserAccountList == null || UserAccountList.Count == 0) { }

                else
                {
                    ModelState.AddModelError("UserName", "El nombre de usuario ya existe");

                    valid = false;

                }

            }

            bool esMail = _mailValidatorManager.ComprobDeMail(data.Email);
            if (!esMail)
            {
                ModelState.AddModelError("Email", "El Email ingresado no es válido");

                valid = false;

            }





            if (valid)

            {
                data.CreationDate = DateTime.Now;
                data.IsActive = true;
                _userAccountManager.Save(data);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                var provinces = _userAccountManager.GetProvinces();
                ViewBag.Provinces = provinces; // Sirve para sumar una lista u accesorios necesarios para una vista que no entran en el modelo original
                return View("NuevoUsuario", data);
            } // No Encuntra la vista correcta!!!!!!!!!!





        }

    }
}
