using GameChanger.Managers;
using GameChanger.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameChanger.Controllers
{
    public class UserAccountController : Controller
    {
        private UserAccountManager _userAccountManager;
        
        public UserAccountController()
        {
            _userAccountManager = new UserAccountManager();

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            UserAccount model = new UserAccount();
            var provinces=_userAccountManager.GetProvinces();
            ViewBag.Provinces = provinces; // Sirve para sumar una lista u accesorios necesarios para una vista que no entran en el modelo original
            return View("NuevoUsuario", model);
        }



    }
}
