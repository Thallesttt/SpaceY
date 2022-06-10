using FluentNHibernate.Mapping;
using SusOnTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Map
{
    public class PacienteMap : ClassMap<Paciente>
    {
        public PacienteMap()
        {
            Table("TB_PACIENTE");
            Id(param => param.Id,"ID").GeneratedBy.Sequence("GN_PACIENTE");
            Map(param => param.Nome, "NOME").Length(60);
            Map(param => param.NumeroSUS, "NUMERO_SUS").Length(20);
            Map(param => param.DataNascimento, "DATA_NASCIMENTO");
        }

    }
}
