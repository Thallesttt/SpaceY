using Microsoft.EntityFrameworkCore;
using SusOnTrack.Enumerado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusOnTrack.Model
{
    public class VacinaContext : DbContext
    {
        private readonly string _connectionstring;
        public VacinaContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionstring);
        }
        public DbSet<Vacina> Vacinas { get; set; }
    }
    [Table("TB_VACINA")]
    public class Vacina
    {

        [Column("ID")]
        public virtual Int64 Id { get; set; }
    
        [Column("CONTEUDO")]
        public virtual long Conteudo { get; set; }
        [Column("TIPO_VACINA")]
        public virtual Tipo_Vacina Tipo { get; set; }


    }
}
