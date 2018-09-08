using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    /// <summary>
    /// Después de que el candidato es entrevistado 
    /// </summary>
    public class AnalisisCandidato
    {
        [Key]
        [ForeignKey(nameof(EntrevistaCandidato))]
        public int EntrevistaCandidatoId { get; set; }
        public EntrevistaCandidato EntrevistaCandidato { get; set; }

        public DateTime Fecha { get; set; }
        
        public string ObservacionesRecursosHumanos { get; set; }
        public string ObservacionesTecnicas { get; set; }

        public bool Aceptado { get; set; }
    }
}
