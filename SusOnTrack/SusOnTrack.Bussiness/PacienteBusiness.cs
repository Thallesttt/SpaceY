using System;
using SusOnTrack.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SusOnTrack.Repository;


namespace SusOnTrack.Bussiness
{
    public class PacienteBussiness : IDisposable
    {
        private bool disposedValue;
        private IPacienteRepository _repositorio;

        public PacienteBussiness(IPacienteRepository repo) { _repositorio = repo; }

        public void BindView(Paciente _paciente, dynamic view)
        {
            _paciente.Nome = view.Nome;
            _paciente.NumeroSUS = view.NumeroSUS;
            _paciente.DataNascimento = Convert.ToDateTime(view.DataNascimento);
        }

        public async Task Gravar(dynamic view)
        {
            Paciente Paciente = this.check();

            if (Paciente == null)
                Paciente = new Paciente();

            this.BindView(Paciente, view);

        }
        public Paciente check() 
        {
            //SqlQuery
            
            return new Paciente();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        // ~PacienteBussiness()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
