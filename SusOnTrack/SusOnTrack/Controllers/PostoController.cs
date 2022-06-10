using SusOnTrack.ControllersWebApi;
using SusOnTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SusOnTrack.Controllers
{
    public class PostoController : Controller
    {
        public ActionResult Index() { return View(); }
        [HttpGet]
        public ActionResult Cadastro(long? Id) { return View(); }

        [HttpPost]
        public ActionResult Cadastro(PostoCadastroModel value)
        {
            using (var api = new PostoApiController())
            {
                var retorno = api.Gravar(value)?.Result;

                return View(retorno.objeto);
            }
        }
    }
}