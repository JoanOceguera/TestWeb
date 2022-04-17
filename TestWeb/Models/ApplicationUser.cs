using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Model;
using Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace TestWeb.Models
{
     
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Expediente")]
        public int exp { get; set; }
        [Display(Name = "Área")]
        public int area { get; set; }
        [Display(Name = "Activo")]
        public bool activo { get; set; }
        [Display(Name = "Carnet de Identidad")]
        public string carneId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

    public async static Task<ClaimsIdentity> CreateUserClaims(ClaimsIdentity identity, UserManager<ApplicationUser> manager,RoleManager<ApplicationRol> roleManager, string userId)
        {
            var currentUser = await manager.FindByIdAsync(userId);
            var rol = await roleManager.FindByIdAsync(currentUser.Roles.ToList().Single().RoleId);
            RecursosHumanosEntities rhData = new RecursosHumanosEntities();
            var jUser = "";

            if (rhData.Personal.Find(int.Parse(currentUser.UserName)) != null)
            {
                var rhPerson = rhData.Personal.Find(int.Parse(currentUser.UserName));
                jUser = JsonConvert.SerializeObject(new CurrentUser
                {
                    UserId = currentUser.Id,
                    area = currentUser.area,
                    UserName = currentUser.UserName,
                    Email = currentUser.Email,
                    Role = rol.Name,
                    FullName = FunYCon.TConeccion.Revisar_Ort(rhPerson.Nombre + ' ' + rhPerson.Apellido1 + ' ' + rhPerson.Apellido2),
                    exp = currentUser.exp
                });
            }
            else
            {
                var rhPerson = rhData.BajasPers.Where(x => x.Exp == currentUser.exp && x.CarneId == currentUser.carneId).FirstOrDefault();
                jUser = JsonConvert.SerializeObject(new CurrentUser
                {
                    UserId = currentUser.Id,
                    area = currentUser.area,
                    UserName = currentUser.UserName,
                    Email = currentUser.Email,
                    Role = rol.Name,
                    FullName = FunYCon.TConeccion.Revisar_Ort(rhPerson.Nombre + ' ' + rhPerson.Apellido1 + ' ' + rhPerson.Apellido2),
                    exp = currentUser.exp
                });
            }
            // Your User Data
            //var jUser = JsonConvert.SerializeObject(new CurrentUser
            //{
            //    UserId = currentUser.Id,
            //    area = currentUser.area,
            //    UserName = currentUser.UserName,
            //    Email = currentUser.Email,
            //    Role = rol.Name,
            //    FullName = FunYCon.TConeccion.Revisar_Ort(rhPerson.Nombre + ' ' + rhPerson.Apellido1 + ' ' + rhPerson.Apellido2),
            //    exp =  currentUser.exp

            //});

            identity.AddClaim(new Claim(ClaimTypes.UserData, jUser));

            return await Task.FromResult(identity);
        }

        public async static Task LogIn(ApplicationUser user, UserManager<ApplicationUser> manager, RoleManager<ApplicationRol> roleManager, IAuthenticationManager AuthenticationManager)
        {
            var identity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            identity = await CreateUserClaims(
                identity,
                manager, roleManager,
                user.Id
            );

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);

        }
    }
}