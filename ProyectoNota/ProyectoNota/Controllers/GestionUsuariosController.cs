namespace ProyectoNota.Controllers
{
    using Microsoft.AspNet.Identity.Owin;
    using ProyectoNota.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = "ADMINISTRADOR")]
    public class GestionUsuariosController : Controller
    {

        ApplicationDbContext userContext;

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public GestionUsuariosController()
        {
            userContext = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<ActionResult> BandejaUsuarios()
        {
            return await Task<ActionResult>.Factory.StartNew(() =>
            {
                return View(userContext.Users.ToList());
            });
        }

        [HttpGet]
        public async Task<ActionResult> CrearUsuarioSistema()
        {
            return await Task<ActionResult>.Factory.StartNew(() =>
            {
                return View();
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearUsuarioSistema(RegisterViewModel _usuario)
        {
            var resultado = await UserManager.CreateAsync(new ApplicationUser { NombreCompleto = _usuario.NombreCompleto, NumeroDocumento = _usuario.NumeroDocumento, UserName = _usuario.Email, Email = _usuario.Email }, _usuario.Password);

            if (!resultado.Succeeded)
                return View();

            return RedirectToAction("BandejaUsuarios", "GestionUsuarios", new { area = "" });
        }

        [HttpGet]
        public async Task<ActionResult> DetalleUsuario(string _guid)
        {
            return View(await UserManager.FindByIdAsync(_guid));
        }

        [HttpGet]
        public async Task<ActionResult> EliminarUsuario(string _guid)
        {
            var resultado = await UserManager.DeleteAsync(await UserManager.FindByIdAsync(_guid));
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> RolesUsuario(string _guid)
        {
            return View(await UserManager.GetRolesAsync(_guid));
        }

        [HttpGet]
        public async Task<ActionResult> AgregarRol(string _guid)
        {
            return await Task<ActionResult>.Factory.StartNew(() =>
            {
                SelectList mostrarListaRoles = new SelectList(userContext.Roles.ToList(), "Id", "Name");
                ViewBag.Roles = mostrarListaRoles;
                ViewBag.Usuario = _guid;
                return View();
            });
        }

        [HttpPost]
        public async Task<ActionResult> AgregarRol(Rol _rol, string _guid)
        {
            var rolObtenido = (from roles in userContext.Roles
                               where roles.Id == _rol.IdRol
                               select roles).FirstOrDefault();
            await UserManager.AddToRoleAsync(_guid, rolObtenido.Name);
            return RedirectToAction("BandejaUsuarios", "GestionUsuarios", new { area = "" });
        }

        [HttpGet]
        public async Task<ActionResult> EliminarRol(string _guid, string _nombreRol)
        {
            await UserManager.RemoveFromRoleAsync(_guid, _nombreRol);
            return RedirectToAction("RolesUsuario", "GestionUsuarios", new { area = "" });
        }
    }
}