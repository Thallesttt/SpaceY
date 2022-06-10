using Constantes.Classes;
using SusOnTrack.Model;
using SusOnTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SusOnTrack.ControllersWebApi
{
    public class VacinaApiController : ApiController
    {
        [HttpPost()]
        [Route("api/VacinaApi/GetAll")]
        public async Task<ResponsePattern<List<VacinaListagemModel>>> GetAll()
        {
            ResponsePattern<List<VacinaListagemModel>> retorno = new ResponsePattern<List<VacinaListagemModel>>
            {
                objeto = new List<VacinaListagemModel>()
            };
            try
            {
                using (VacinaContext DataBase = new VacinaContext(RouteDB_EF.ConnectionString))
                {
                    List<Vacina> vacinas = DataBase.Vacinas.ToList();
                    List<VacinaListagemModel> vacinasSelecionadas = vacinas.Select(p =>
                    {
                        return new VacinaListagemModel
                        {
                            Id = Convert.ToString(p.Id),
                            Codigo = "",
                            Conteudo = "",
                            Valor = "",
                            //IdPesquisa""
                        };
                    }).ToList();
                    retorno.objeto = vacinasSelecionadas;

                }
                retorno.execution = true;

            }
            catch (Exception erro)
            {
                retorno.execution = false;
                _ = erro.Message;
            }
            return retorno;
        }

        [HttpPost()]
        [Route("api/PacienteApi/FindRecord")]
        public async Task<ResponsePattern<VacinaCadastroModel>> FindRecord(long? Id)
        {
            ResponsePattern<VacinaCadastroModel> retorno = new ResponsePattern<VacinaCadastroModel>();

            try
            {
                using (VacinaContext DataBase = new VacinaContext(RouteDB_EF.ConnectionString))
                {
                    List<Vacina> vacinas = DataBase.Vacinas.ToList();
                    Vacina vacinaSelecionada = vacinas.Find(p => p.Id == Id);

                    var view = new VacinaCadastroModel();
                    GetView(vacinaSelecionada, view);
                    retorno.objeto = view;

                }
                retorno.execution = true;

            }
            catch (Exception erro)
            {
                retorno.execution = false;
                _ = erro.Message;
            }
            return retorno;
        }

        public void GetView(Vacina vacina, VacinaCadastroModel view)
        {
            view.Id = vacina.Id;
            //view.Nome = vacina.;
            //view.NumeroSUS = vacina.NumeroSUS;
            //view.DataNascimento = vacina.DataNascimento.ToString("dd/MM/yyyy");

        }


        [HttpPost()]
        [Route("api/VacinaApi/Gravar")]
        public async Task<ResponsePattern<Int64>> Gravar(VacinaCadastroModel view)
        {

            var retorno = new ResponsePattern<long>();
            try
            {

                using (VacinaContext DataBase = new VacinaContext(RouteDB_EF.ConnectionString))
                using (Tipo_VacinaContext repoTipo = new Tipo_VacinaContext(RouteDB_EF.ConnectionString))
                {
                    //var repo = new PacienteRepository(session);
                    List<Vacina> Vacinas = DataBase.Vacinas.ToList();
                    var vacina = new Vacina();

                    vacina.Id = view.Id;
                    vacina.Conteudo = view.Conteudo;
                    //vacina.Tipo = view.Tipo;

                    //vacina.Nome = view.Nome;
                    //vacina.NumeroSUS = view.NumeroSUS;
                    //vacina.DataNascimento = Convert.ToDateTime(view.DataNascimento);

                    if (DataBase.Vacinas.Find(view.Id) != null)

                        DataBase.Update<Vacina>(vacina);
                    else 
                    { 
                        vacina.Id = Vacinas.Count() + 1;
                        DataBase.Add<Vacina>(vacina);
                    }
                    DataBase.SaveChanges();
                }
                retorno.execution = true;
            }
            catch (Exception erro)
            {
                retorno.execution = false;
                _ = erro.Message;
            }
            return retorno;
        }


        [HttpGet()]
        [Route("api/VacinaApi/Excluir")]
        public async Task<ResponsePattern<Int64>> Excluir(long id)
        {
            var retorno = new ResponsePattern<Int64>();
            try
            {
                using (VacinaContext DataBase = new VacinaContext(RouteDB_EF.ConnectionString))
                {

                    Vacina vacinaSelecionada = await DataBase.Vacinas.FindAsync(id);
                    DataBase.Remove(vacinaSelecionada);
                    await DataBase.SaveChangesAsync();
                    retorno.Id = id;
                }
                retorno.execution = true;
            }
            catch (Exception erro)
            {
                retorno.execution = false;
                _ = erro.Message;
            }

            return retorno;
        }

        [AcceptVerbs("Get", "Post")]
        [Route("api/PostoApi/OptionComboVacinas")]
        public async Task<Dictionary<long, String>> OptionComboVacinas()
        {
            var parametros = new Dictionary<long, String>();
            using (var Database = new VacinaContext(RouteDB_EF.ConnectionString))
            {
                parametros = Database.Vacinas.ToDictionary(p => p.Id, p => String.Format("{0} ml", p.Conteudo));
            }

            return parametros;
        }
    }
}