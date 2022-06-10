//using Aniel.Connect.Core;
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
    public class PacienteController : Controller
    {

        public ActionResult Index() { return View(); }
        public ActionResult Cadastro(long? Id)
        {
            using (var api = new PacienteApiController())
            {
                var retorno = api.FindRecord(Id)?.Result;
                
                return View(retorno.objeto);
            }
        }
        [HttpPost]
        public ActionResult Cadastro(PacienteCadastroModel value)
        {
            using (var api = new PacienteApiController())
            {
                var retorno = api.Gravar(value)?.Result;
                
                return RedirectToAction("Cadastro","Paciente", new{@Id = retorno.Id });
            }
        }
        public ActionResult Delete() 
        {
            using (var api = new PacienteApiController())
            {
                //var retorno = api.FindRecord(Id)?.Result;

                return View();
            }
        }
        [HttpPost()]
        public ActionResult Delete(long Id)
        {
            using (var api = new PacienteApiController())
            {
                var retorno = api.Excluir(Id)?.Result;

                return View(retorno.objeto);
            }
        }
    }
}