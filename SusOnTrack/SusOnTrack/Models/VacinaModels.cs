using SusOnTrack.Enumerado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SusOnTrack.Models
{
    public class VacinaListagemModel
    {        

        public String Id { get; set; }
        public String Conteudo { get; set; }
        public String Valor { get; set; }
        public String Codigo { get; set; }
        public Int16? IdPesquisa { get; set; }
    }
    public class VacinaCadastroModel
    {
        public Int64 Id { get; set; }
        public Int32 Conteudo { get; set; }
        public TipoVacinaEnum Tipo { get; set; }
        public long Id_PostoVinculado { get; set; }
        public String Valor { get; set; }
        public long Codigo { get; set; }
    }
}