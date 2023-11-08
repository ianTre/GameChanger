using GameChanger.Managers;
using GameChanger.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username,string passoword)
        {
            //Check for credentials
            bool isLegit = _userAccountManager.CheckforCredentials(username, passoword);
            if(!isLegit)
            {
                ViewData["ErrorFlag"] = "Las credenciales ingresadas no son correctas";
                return View();
            }
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name,username)
            };
            var identity = new ClaimsIdentity(claims,"CookieAuthentication");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("CookieAuthentication", principal);

            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult New()
        {
            UserAccount model = new UserAccount();
            var provinces = _userAccountManager.GetProvinces();
            model.BirthDate= DateTime.Now;
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

            if (!string.IsNullOrEmpty(data.DNI))
            {
                data.DNI = data.DNI.Trim().Replace(".", "");
            }
            
            bool esDNI = _userAccountManager.ComprobDeDNI(data.DNI);
            if (!esDNI)  
            {
                ModelState.AddModelError("DNI", "Ingresar DNI con Formato Válido");
                valid = false;
            }

            if (string.IsNullOrEmpty(data.Name))
            {
                ModelState.AddModelError("Name", "Ingresar Nombre es obligatorio");
                valid = false;
            }
            if (string.IsNullOrEmpty(data.Surname))
            {
                ModelState.AddModelError("Surname", "Ingresar Apellido es obligatorio");
                valid = false;
            }

            //8 caracteres ,1 mayuscula , 1 numero, 1 simbolo
            if (!string.IsNullOrEmpty(data.Password))
            {
                

            }



            if (valid) //Ultimo paso
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
            } 
        }
    }
}
