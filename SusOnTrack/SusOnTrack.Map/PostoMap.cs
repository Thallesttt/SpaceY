using FluentNHibernate.Mapping;
using SusOnTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Map
{
    public class PostoMap: ClassMap<Posto>
    {
        public PostoMap() 
        {
            Table("TB_POSTO");
            Id(param=>param.Id,"ID").GeneratedBy.Sequence("GN_POSTO");
            Map(param=>param.NomeInstituicao,"").Length(100);
            HasMany(param=>param.VacinasDisponiveis).KeyColumn("ID_VACINA").Cascade.All().Inverse();
        }       
        
    }
}
