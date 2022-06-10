using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Repository
{
    public class PacienteRepository : IPacienteRepository
    {

        private ISession _session;

        public PacienteRepository(ISession session)
        {
            this._session = session;
        }

        public async Task<String> selectFirst(long Id)
        {
            return "";
        }
    }
}
