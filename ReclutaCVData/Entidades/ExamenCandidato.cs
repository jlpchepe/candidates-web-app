using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public enum TipoExamenCandidato
    {
        [Description("Programación")]
        Programación,
        [Description("Analista")]
        Analista,
        [Description("Administrador de proyectos")]
        AdministradorDeProyectos,
        [Description("Mesa de servicios")]
        MesaDeServicios,
        [Description("Ingeniero de pruebas")]
        IngenieroDePruebas
    }

    /// <summary>
    /// Examen de candidato
    /// </summary>
    public class ExamenCandidato
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PrimeraLlamadaCandidato))]
        [Index("IX_Tipo_Candidato", 1, IsUnique = true)]
        public int PrimeraLlamadaCandidatoId { get; set; }
        public PrimeraLlamadaCandidato PrimeraLlamadaCandidato { get; set; }

        [Index("IX_Tipo_Candidato", 0, IsUnique = true)]
        public TipoExamenCandidato Tipo { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Calificacion { get; set; }

        public string Observaciones { get; set; }
    }
}
