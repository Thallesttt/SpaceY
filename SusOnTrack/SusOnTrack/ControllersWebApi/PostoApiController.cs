using Constantes.Classes;
using SusOnTrack.Enumerado;
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
    public class PostoApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [Route("api/PostoApi/GetAll")]
        public async Task<ResponsePattern<List<PostoListagemModel>>> GetAll()
        {
            ResponsePattern<List<PostoListagemModel>> retorno = new ResponsePattern<List<PostoListagemModel>>
            {
                objeto = new List<PostoListagemModel>()
            };
            try
            {
                using (PostoContext DataBase = new PostoContext(RouteDB_EF.ConnectionString))
                {
                    List<Posto> postos = DataBase.Postos.ToList();
                    List<PostoListagemModel> PostosSelecionados = postos.Select(p =>
                    {
                        return new PostoListagemModel
                        {
                            Id = p.Id,
                            //IdPesquisa=p.,
                            NomeInstituicao = p.NomeInstituicao,
                            //Posicao = p.Posicao,
                        };
                    }).ToList();
                    retorno.objeto = PostosSelecionados;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("api/PostoApi/FindRecord")]
        public async Task<ResponsePattern<PostoCadastroModel>> FindRecord(long? Id)
        {
            ResponsePattern<PostoCadastroModel> retorno = new ResponsePattern<PostoCadastroModel>();

            try
            {
                using (PostoContext DataBase = new PostoContext(RouteDB_EF.ConnectionString))
                {
                    List<Posto> postos = DataBase.Postos.ToList();
                    Posto postoSelecionado = postos.Find(p => p.Id == Id);

                    var view = new PostoCadastroModel();
                    GetView(postoSelecionado, view);
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

        public void GetView(Posto posto, PostoCadastroModel view)
        {
            view.Id = posto.Id;
            view.NomeInstituicao = posto.NomeInstituicao;
            //view.Posicao = posto.Posicao;
            view.VacinasDisponiveis = posto.VacinasDisponiveis.Select(p =>
            {
                return new Listagem_VacinasPostoViewModel
                {
                    Id = p.Id,
                    Descricao = ""
                };
            }).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("api/PostoApi/Gravar")]
        public async Task<ResponsePattern<Int64>> Gravar(PostoCadastroModel view)
        {

            var retorno = new ResponsePattern<long>();
            try
            {

                using (PostoContext DataBase = new PostoContext(RouteDB_EF.ConnectionString))
                using (Tipo_VacinaContext repoTipo = new Tipo_VacinaContext(RouteDB_EF.ConnectionString))
                {
                    //var repo = new PacienteRepository(session);
                    var postos = DataBase.Postos.ToList();
                    var posto = new Posto();

                    posto.Id = view.Id;
                    posto.NomeInstituicao = view.NomeInstituicao;
                    //posto.Posicao = view.Posicao;
                    posto.VacinasDisponiveis = view.VacinasDisponiveis.Select(p =>
                    {
                        return new Vacina
                        {
                            Id = 0,
                            
                            Tipo = repoTipo.Tipos_Vacinas.Find(p.Id)
                        };
                    }).ToList();

                    if (DataBase.Postos.Find(view.Id) != null)

                        DataBase.Update<Posto>(posto);
                    else
                    {
                        posto.Id = postos.Count() + 1;
                        DataBase.Add<Posto>(posto);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/PostoApi/Excluir")]
        public async Task<ResponsePattern<Int64>> Excluir(long id)
        {
            var retorno = new ResponsePattern<Int64>();
            try
            {
                using (PostoContext DataBase = new PostoContext(RouteDB_EF.ConnectionString))
                {

                    Posto postoSelecionado = DataBase.Postos.Find(id);
                    DataBase.Remove(postoSelecionado);
                    DataBase.SaveChanges();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("Get", "Post")]
        [Route("api/PostoApi/OptionComboPosto")]
        public async Task<Dictionary<long, String>> OptionComboPosto()
        {
            var parametros = new Dictionary<long, String>();
            using (var Database = new PostoContext(RouteDB_EF.ConnectionString))
            {
                parametros = Database.Postos.ToDictionary(p => p.Id, p => p.NomeInstituicao);
            }

            return parametros;
        }
    }
}