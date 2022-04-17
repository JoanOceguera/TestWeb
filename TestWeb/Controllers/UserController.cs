using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;
using Model;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Configuration;
using Model.Entities;

namespace TestWeb.Controllers
{
    public class UserController : Controller
    {
        private IncideEntities incideData = new IncideEntities();
        public UserController()
        {
        }


        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> Usuarios()
        {
            List<UsuarioIndexModel> usuarios = new List<UsuarioIndexModel>();
            foreach (var item in UserManager.Users.ToList())
            {
                var area = incideData.Area.Find(item.area).descripcion;
                var rol = await RoleManager.FindByIdAsync(item.Roles.ToList().FirstOrDefault().RoleId);
                usuarios.Add(new UsuarioIndexModel(item.Id, item.UserName, item.Email, item.exp, area, rol.Name, item.activo));

            }
            return View(usuarios);
        }

        [Authorize]
        public ActionResult Roles()
        {
            return View(RoleManager.Roles.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UsuarioRol(ChangeRolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByIdAsync(model.UserId);
            user.Roles.Clear();
            var result = await UserManager.AddToRoleAsync(model.UserId, model.Rol);
            if (!result.Succeeded)
            {
                AddErrors(result);
                ViewBag.UserId = new SelectList(UserManager.Users, "Id", "UserName", model.UserId);
                ViewBag.Rol = new SelectList(RoleManager.Roles, "Name", "Name", model.Rol);
                return View();
            }
            return RedirectToAction("UsuarioRol", new { message = ManageMessageId.ChangeRolSuccess});
        }

        [HttpGet]
        public ActionResult UsuarioRol (ManageMessageId? message)
        {
            ViewBag.UserId = new SelectList(UserManager.Users, "Id", "UserName"); 
            ViewBag.Rol = new SelectList(RoleManager.Roles, "Name", "Name");
            ViewBag.StatusMessage =
                message == ManageMessageId.Error ? "Se ha producido un error al cambiar el rol del usuario, por favor intentelo más tarde."
                : message == ManageMessageId.ErrorSameRol ? "El usuario ya se encuentra en el rol seleccionado, por favor seleccione otro."
                : message == ManageMessageId.ChangeRolSuccess ? "El rol del usuario se ha cambiado satisfactoriamente."
                : "";
            return View(); 
        }

        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            user.activo = false;
            await UserManager.UpdateAsync(user);
            return RedirectToAction("Usuarios");
        }

        [Authorize]
        public async Task<ActionResult> Activate(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            user.activo = true;
            await UserManager.UpdateAsync(user);
            return RedirectToAction("Usuarios");
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddRole(AddRolViewModel model)
        {
            ApplicationRol rol = new ApplicationRol()
            {
                Name = model.Name
            };
            var result = await RoleManager.CreateAsync(rol);
            if (result.Succeeded)
            {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                KeyValueConfigurationElement keyValue = new KeyValueConfigurationElement(rol.Id, rol.Name);
                config.AppSettings.Settings.Add(keyValue);
                config.Save(ConfigurationSaveMode.Modified);
                return RedirectToAction("Roles");
            }
            AddErrors(result);
            return View(model);
            
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditRole(string Id)
        {
            ApplicationRol rol = RoleManager.FindById(Id);
            EditRolViewModel model = new EditRolViewModel
            {
                Id = rol.Id,
                name = rol.Name
            };
            return View(model);

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> EditRole(EditRolViewModel model)
        {
            ApplicationRol rol = await RoleManager.FindByIdAsync(model.Id);
            rol.Name = model.name;
            var result = await RoleManager.UpdateAsync(rol);
            if (result.Succeeded)
            {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings[rol.Id].Value = rol.Name;
                config.Save(ConfigurationSaveMode.Modified);
                return RedirectToAction("Roles");
            }
            AddErrors(result);
            return View(model);

        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit (string id)
        {
            var user = UserManager.FindById(id);
            EditUserViewModel model = new EditUserViewModel()
            {
                UserName = user.UserName,
                id = user.Id,
                Email = user.Email,
                area = user.area,
                exp = user.exp,
                carneId = user.carneId
            };
            ViewBag.areas = incideData.Area.OrderBy(x => x.descripcion).ToList();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage email = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    email.To.Add(model.Email);
                    email.Subject = "Notificación de Correo";
                    email.SubjectEncoding = System.Text.Encoding.UTF8;
                    email.Body = "Su correo es válido";
                    email.BodyEncoding = System.Text.Encoding.UTF8;
                    email.IsBodyHtml = false;
                    client.Send(email);
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Introduzca un correo válido");
                    return View(model);
                }
                var user = UserManager.FindById(model.id);
                user.carneId = model.carneId;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.exp = model.exp;
                user.area = model.area;
                var result = UserManager.Update(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Usuarios");
                }
                AddErrors(result);
                
            }
            return View(model); 
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            Error,
            ErrorSameRol,
            ChangeRolSuccess
        }
    }
}
