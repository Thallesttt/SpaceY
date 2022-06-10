using Constantes.Classes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NHibernate;
using SusOnTrack.Bussiness;
using SusOnTrack.Enumerado;
using SusOnTrack.Model;
using SusOnTrack.Models;
using SusOnTrack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace SusOnTrack.ControllersWebApi
{
    public class PacienteApiController : ApiController
    {
        [HttpPost()]
        [Route("api/PacienteApi/GetAll")]
        public async Task<ResponsePattern<List<PacienteListagemModel>>> GetAll()
        {
            ResponsePattern<List<PacienteListagemModel>> retorno = new ResponsePattern<List<PacienteListagemModel>>();
            try
            {

                using (PacienteContext DataBase = new PacienteContext(RouteDB_EF.ConnectionString))
                {
                    List<Paciente> pacientes = DataBase.Pacientes.ToList();
                    List<PacienteListagemModel> InfoSelecionadas = new List<PacienteListagemModel>();

                    InfoSelecionadas = pacientes.Select(p =>
                    {
                        return new PacienteListagemModel
                        {
                            Id = Convert.ToString(p.Id),
                            Codigo = Convert.ToString(p.NumeroSUS),
                            Valor = Convert.ToString(p),
                            Data_Nascimento = p.DataNascimento.ToString("dd/MM/yyyy")
                        };
                    }).ToList();


                    retorno.objeto = InfoSelecionadas;

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
        [Route("api/PacienteApi/GetRecordsPaciente")]
        public async Task<ResponsePattern<Paciente_FilaEsperaModel>> GetRecordsPaciente()
        {
            ResponsePattern<Paciente_FilaEsperaModel> retorno = new ResponsePattern<Paciente_FilaEsperaModel>();
            try
            {

                using (PacienteContext DataBase = new PacienteContext(RouteDB_EF.ConnectionString))
                {
                    List<Paciente> pacientes = DataBase.Pacientes.ToList();

                    Paciente_FilaEsperaModel InfoSelecionadas = new Paciente_FilaEsperaModel
                    {
                        Registros = pacientes.ToDictionary(prop => prop.Nome, prop => prop.Tipo_Vacina.Descricao)
                    };

                    retorno.objeto = InfoSelecionadas;

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
        [Route("api/PacienteApi/GetNumberRecords")]
        public async Task<ResponsePattern<Paciente_NumberRecordsModel>> GetNumberRecords()
        {
            ResponsePattern<Paciente_NumberRecordsModel> retorno = new ResponsePattern<Paciente_NumberRecordsModel>();
            try
            {

                using (PacienteContext DataBase = new PacienteContext(RouteDB_EF.ConnectionString))
                using (Tipo_VacinaContext DataBaseVacinas = new Tipo_VacinaContext(RouteDB_EF.ConnectionString))
                {
                    List<Paciente> pacientes = DataBase.Pacientes.ToList();
                   
                    List<Tipo_Vacina> vacinas = DataBaseVacinas.Tipos_Vacinas.ToList();


                    Paciente_NumberRecordsModel InfoSelecionadas = new Paciente_NumberRecordsModel
                    {
                        Numero_Pacientes = new Dictionary<String, Int64>()
                    };

                    foreach (var item in vacinas)
                    {
                        InfoSelecionadas.Numero_Pacientes.Add(item.Descricao, pacientes.Where(p => p.Tipo_Vacina == item).ToList().Count());
                    }

                    retorno.objeto = InfoSelecionadas;

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
        [Route("api/PacienteApi/GetAccessInfo")]
        public async Task<dynamic> getAccessInfo(short number)
        {
            dynamic retorno = String.Empty;
            try
            {
                switch (number)
                {
                    case 0:
                        retorno = (await this.GetAll()).objeto;
                        break;
                    case 1:
                        retorno = (await this.GetNumberRecords()).objeto;
                        break;
                    case 2:
                        retorno = (await this.GetRecordsPaciente()).objeto;
                        break;
                }
            }
            catch (Exception erro)
            {
                String Mensagem = erro.Message;
            }
            return retorno;
        }


        [HttpPost()]
        [Route("api/PacienteApi/FindRecord")]
        public async Task<ResponsePattern<PacienteCadastroModel>> FindRecord(long? Id)
        {
            ResponsePattern<PacienteCadastroModel> retorno = new ResponsePattern<PacienteCadastroModel>();

            try
            {
                using (PacienteContext DataBase = new PacienteContext(RouteDB_EF.ConnectionString))
                {
                    List<Paciente> pacientes = DataBase.Pacientes.ToList();
                    Paciente pacienteSelecionado = pacientes.Find(p => p.Id == Id);
                    if (pacienteSelecionado != null)
                    {
                        PacienteCadastroModel view = new PacienteCadastroModel();
                        GetView(pacienteSelecionado, view);
                        retorno.objeto = view;
                    }

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

        public void GetView(Paciente paciente, PacienteCadastroModel view)
        {
            view.Id = paciente?.Id;
            view.Nome = paciente?.Nome;
            view.NumeroSUS = paciente?.NumeroSUS;
            view.DataNascimento = paciente?.DataNascimento.ToString("dd/MM/yyyy");

        }




        [HttpPost()]
        [Route("api/PacienteApi/Gravar")]
        public async Task<ResponsePattern<Int64>> Gravar(PacienteCadastroModel view)
        {

            ResponsePattern<long> retorno = new ResponsePattern<long>();
            try
            {

                using (PacienteContext DataBase = new PacienteContext(RouteDB_EF.ConnectionString))
                {

                    List<Paciente> pacientesDB = DataBase.Pacientes.ToList();
                    Paciente paciente = new Paciente();

                    paciente.Id = view.Id.HasValue ? view.Id.Value : 0;
                    paciente.Nome = view.Nome;
                    paciente.NumeroSUS = view.NumeroSUS;
                    paciente.DataNascimento = Convert.ToDateTime(view.DataNascimento);

                    if (pacientesDB.Find(p => p.Id == view.Id) != null)

                        DataBase.Update<Paciente>(paciente);
                    else
                    {
                        paciente.Id = pacientesDB.Count() + 1;
                        DataBase.Add<Paciente>(paciente);
                    }

                    DataBase.SaveChanges();
                    retorno.Id = paciente.Id;
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
        [Route("api/PacienteApi/Excluir")]
        public async Task<ResponsePattern<Int64>> Excluir(long id)
        {
            ResponsePattern<long> retorno = new ResponsePattern<Int64>();
            try
            {
                using (PacienteContext DataBase = new PacienteContext(RouteDB_EF.ConnectionString))
                {

                    Paciente pacienteSelecionado = DataBase.Pacientes.Find(id);
                    DataBase.Remove(pacienteSelecionado);
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

    }
}