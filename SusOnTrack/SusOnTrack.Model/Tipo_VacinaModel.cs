using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Model
{

    public class Tipo_VacinaContext : DbContext
    {
        private readonly string _connectionstring;
        public Tipo_VacinaContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionstring);
        }
        public DbSet<Tipo_Vacina> Tipos_Vacinas { get; set; }
    }

    [Table("TB_TIPO_VACINA")]   
    public class Tipo_Vacina
    {
        [Column("ID")]              
        public virtual long Id { get; set; }
        [Column("DESCRICAO")]
        public virtual String Descricao { get; set; }
        [Column("OBSERVACAO")]
        public virtual String Observacao { get; set; }
        [Column("RECORRENTE")]
        public virtual Boolean Recorrente { get; set; }

    }
}
