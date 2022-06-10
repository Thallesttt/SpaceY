using Microsoft.EntityFrameworkCore;
using SusOnTrack.Enumerado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SusOnTrack.Model
{
    public class PacienteContext : DbContext
    {
        private readonly string _connectionstring;
        public PacienteContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionstring);
        }
        public DbSet<Paciente> Pacientes { get; set; }
    }

    [Table("TB_PACIENTE")]
    public class Paciente
    {
        [Column("ID")]
        [Required]
        public virtual Int64 Id { get; set; }
        
        [Column("NOME")]
        [MaxLength(60)]
        public virtual String Nome { get; set; }
        
        [Column("NUMERO_SUS")]
        [MaxLength(20)]
        public virtual String NumeroSUS { get; set; }

        [Column("DATA_NASCIMENTO")]
        [DataType(DataType.DateTime)]
        public virtual DateTime DataNascimento { get; set; }

        [Column("TIPO_VACINA")] 
        
        public virtual Tipo_Vacina Tipo_Vacina { get; set; }

    }
}
