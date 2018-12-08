namespace ProyectoNota.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> InicioPlataforma() {
            return await Task<ActionResult>.Factory.StartNew(() => {
                return View();
            });
        }
    }
}