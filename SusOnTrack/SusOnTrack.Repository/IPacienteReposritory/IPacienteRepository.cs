using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Repository
{
    public interface IPacienteRepository
    {
        /// <summary>
        /// Seleciona o Primeiro Registro com determinado Id.
        /// </summary>
        /// <returns></returns>
          Task<String> selectFirst(Int64 Id);
    }
  
}
