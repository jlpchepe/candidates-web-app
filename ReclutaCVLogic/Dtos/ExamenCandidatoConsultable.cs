using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Información de un examen realizado por un candidato
    /// </summary>
    public class ExamenCandidatoConsultable
    {
        public ExamenCandidatoConsultable() { }
        public ExamenCandidatoConsultable(
            int id,
            TipoExamenCandidato tipo, 
            DateTime fecha, 
            decimal calificacion, 
            string observaciones
        )
        {
            Id = id;
            Tipo = tipo;
            Fecha = fecha;
            Calificacion = calificacion;
            Observaciones = observaciones;
        }

        public int Id { get; set; }
        public TipoExamenCandidato Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Calificacion { get; set; }
        public string Observaciones { get; set; }
    }
}