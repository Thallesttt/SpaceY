using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SusOnTrack.Models
{
    public class PostoListagemModel
    {
        public Int64 Id { get; set; }
        public String NomeInstituicao { get; set; }
        public String Posicao { get; set; }
        public Int16? IdPesquisa { get; set; }
    }
    public class PostoCadastroModel
    {
        public virtual Int64 Id { get; set; }
        public virtual String NomeInstituicao { get; set; }
        public virtual String Posicao { get; set; }

        private IEnumerable<Listagem_VacinasPostoViewModel> _vacinasDisp;
        public virtual IEnumerable<Listagem_VacinasPostoViewModel> VacinasDisponiveis
        {
            get
            {
                if (_vacinasDisp == null)
                {

                    _vacinasDisp = new List<Listagem_VacinasPostoViewModel>();

                }
                return _vacinasDisp;
            }

            set { _vacinasDisp = value; }
        }
    }
    public class Listagem_VacinasPostoViewModel
    {
        public long Id { get; set; }
        public String Descricao { get; set; }
    }
}