using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SusOnTrack.Models
{
    public class PacienteListagemModel
    {
        public String Id { get; set; }
        public String Conteudo { get; set; }
        public String Data_Nascimento { get; set; }
        public String Valor { get; set; }
        public String Codigo { get; set; }
        public Int16? IdPesquisa { get; set; }

    }
    public class PacienteCadastroModel
    {
        public Int64? Id { get; set; }
        public String Nome { get; set; }
        public String NumeroSUS { get; set; }
        public String DataNascimento { get; set; }
    }
    public class Paciente_NumberRecordsModel 
    {
        private Dictionary<string, long> _Numero_Pacientes { get; set; }
        public Dictionary<String, Int64> Numero_Pacientes
        {
            get
            {
                return (_Numero_Pacientes == null ? new Dictionary<String, Int64>() : _Numero_Pacientes);
            }
            set
            {
                _Numero_Pacientes = value;
            }
        }
    }
    public class Paciente_FilaEsperaModel
    {
       
        private Dictionary<string, string> _Registros;
        public Dictionary<String, String> Registros
        {
            get
            {
                return (_Registros == null ? new Dictionary<String, String>() : _Registros);
            }
            set
            {
                _Registros = value;
            }
        }

    }
}