using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes.ReporteDeSeguimientoACandidatos
{
    class ReporteDeSeguimientoACandidatos
    {
        public int CurriculumsRecibidos { get; set; }
        public int CumplioConElPerfil { get; set; }
        public int ContinuoConElProceso { get; set; }
        public int RealizaronExamen { get; set; }
        public int Entrevistados { get; set; }
        public int Analizados { get; set; }
        public int Aceptados { get; set; }
        public int Contratados { get; set; }
        public int Descartados { get; set; }
        public int NoLeIntereso { get; set; }
        public int PendientesDeExamen { get; set; }
        public int PendientesDeEntrevistar { get; set; }
        public int PendientesPorAnalizar { get; set; }
        public int Rechazados { get; set; }
        public int NoAceptoLaOferta { get; set; }
        public List<EtapasCandidato> Candidatos { get; set; }
    }   
}
