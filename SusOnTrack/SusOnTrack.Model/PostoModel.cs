using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Model
{
    public class PostoContext : DbContext
    {
        private readonly string _connectionstring;
        public PostoContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionstring);
        }
        public DbSet<Posto> Postos { get; set; }
    }

    [Table("TB_POSTO")]
    public class Posto
    {
        [Column("ID")] 
        public virtual Int64 Id { get; set; }
        [Column("NOME_INSTITUICAO")] 
        public virtual String NomeInstituicao { get; set; }
        //[Column("POSICAO")] 
        //public virtual String Posicao { get; set; }     
        [Column("VACINAS_DISPONIVEIS")]
        public virtual IEnumerable<Vacina> VacinasDisponiveis
        {
            get
            {
                if (_vacinasDisp == null)
                {
                    _vacinasDisp = new List<Vacina>();

                }
                return _vacinasDisp;
            }

            set { _vacinasDisp = value; }
        }
        private IEnumerable<Vacina> _vacinasDisp;

    }
}
