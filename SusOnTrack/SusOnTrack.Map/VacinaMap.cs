using FluentNHibernate.Mapping;
using SusOnTrack.Enumerado;
using SusOnTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Map
{
    public class VacinaMap:ClassMap<Vacina>
    {
        public VacinaMap()
        {
            Table("VACINA");
            Id(param=>param.Id,"ID").GeneratedBy.Sequence("GN_VACINA");
            Map(param=>param.Tipo,"TIPO_VACINA").CustomType<TipoVacinaEnum>();
            Map(param => param.Conteudo,"CONTEUDO");
            //References(param => param.PostoVinculado, "POSTO_VINCULADO").ForeignKey("FK_VACINA_POSTO_VINC");
        }
    }
}
