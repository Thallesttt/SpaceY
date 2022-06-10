using Microsoft.VisualStudio.TestTools.UnitTesting;
using SusOnTrack.ControllersWebApi;
using SusOnTrack.Models;
using System;
using System.Threading.Tasks;

namespace SusOnTrack.UnitTest
{
    [TestClass]
    public class PacienteApiTest
    {
        [TestMethod]
        public async Task Teste()
        {
            PacienteApiController PacienteApi = new PacienteApiController();
            var view = new PacienteCadastroModel();
            Assert.IsNotNull(view,"Paciente nulo");
            try
            {
                await PacienteApi.Gravar(view);
            }
            
            catch (Exception erro) { throw erro; } 
        }
    }
}
