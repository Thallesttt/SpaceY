using SusOnTrack.Constantes;
using SusOnTrack.ControllersWebApi;
using SusOnTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SusOnTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class VacinaController: Controller
    {                          
        public ActionResult Index() { return View(); }
        [HttpGet]
        public ActionResult Cadastro(long? Id) { return View(); }

        [HttpPost]
        public ActionResult Cadastro(VacinaCadastroModel value)
        {
            using (var api = new VacinaApiController())
            {
                var retorno = api.Gravar(value)?.Result;

                return View(retorno.objeto);
            }
        }

        public ActionResult Teste() { return View(); }

        

    }
    
    #region teste

    #endregion

}