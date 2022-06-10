using Constantes.Classes;
using NHibernate;
//using Sinapse.DAO.repository;
using SusOnTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SusOnTrack.ControllersWebApi
{
    public class HomeApiController : ApiController
    {
        [HttpGet()]
        [Route("api/HomeApi/SayHi")]
        public async Task<String> SayHi()
        { return "Hi"; }

        [HttpPost()]
        [Route("api/HomeApi/Carousel")]
        public async Task<ResponsePattern<Carousel>> Carousel(long miliseconds = 100)
        {
            var retorno = new ResponsePattern<Carousel>
            {
                objeto = new Carousel { Itens = new List<ItemCarousel>() }
            };
            try
            {
                //using (ISession session = HibernateUtil.GetSession())
                //{
                //    StringBuilder sql = new StringBuilder(),
                //                  sqlFrom = new StringBuilder(),
                //                  sqlWhere = new StringBuilder();
                //    sql.AppendLine("");
                //}

            }
            catch (Exception erro)
            {
                retorno.execution = false;
                Console.WriteLine(erro.Message);

            }
            return new ResponsePattern<Carousel>
            {
                objeto = new Carousel { Itens = new List<ItemCarousel>() }
            };
        }

        [HttpPost()]
        [Route("api/HomeApi/Excluir")]
        public async Task ExcluirItem()
        { }
    }
}