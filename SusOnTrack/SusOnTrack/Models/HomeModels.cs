using Constantes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SusOnTrack.Models
{
    public class HomeModel
    {

        public String Id { get; set; }
        public String Conteudo { get; set; }
        public String Valor { get; set; }
        public String Codigo { get; set; }
    }

    public class Carousel
    {
        public string Id { get; set; }
        public long milisegundos_paginacao { get; set; }
        private List<ItemCarousel> _Itens;
        public List<ItemCarousel> Itens
        {
            get
            {
                if (_Itens == null)
                {
                    _Itens = new List<ItemCarousel>();
                }
                return _Itens;
            }
            set
            {
                _Itens = value;
            }
        }
    }
    public class ItemCarousel
    {
        public Int32 Id { get; set; }
        public String Descricao { get; set; }
        public String Color { get; set; }
    }
}