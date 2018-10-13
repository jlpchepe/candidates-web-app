using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Reportes.ReporteDeSeguimientoACandidatos
{
    public class ReporteDeSeguimientoACandidatos
    {
        public ReporteDeSeguimientoACandidatos(
            int curriculumsRecibidos, 
            int cumplioConElPerfil, 
            int continuoConElProceso, 
            int realizaronExamen, 
            int entrevistados, 
            int analizados, 
            int aceptados, 
            int contratados, 
            int descartados, 
            int noLeIntereso, 
            int pendientesDeExamen, 
            int pendientesDeEntrevistar, 
            int pendientesPorAnalizar, 
            int rechazados, 
            int noAceptoLaOferta, 
            int aceptoLaOferta,
            List<EtapasCandidato> candidatos
        )
        {
            CurriculumsRecibidos = curriculumsRecibidos;
            CumplioConElPerfil = cumplioConElPerfil;
            ContinuoConElProceso = continuoConElProceso;
            RealizaronExamen = realizaronExamen;
            Entrevistados = entrevistados;
            Analizados = analizados;
            Aceptados = aceptados;
            Contratados = contratados;
            Descartados = descartados;
            NoLeIntereso = noLeIntereso;
            PendientesDeExamen = pendientesDeExamen;
            PendientesDeEntrevistar = pendientesDeEntrevistar;
            PendientesPorAnalizar = pendientesPorAnalizar;
            Rechazados = rechazados;
            NoAceptoLaOferta = noAceptoLaOferta;
            AceptoLaOferta = aceptoLaOferta;
            Candidatos = candidatos;
        }

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
        public int AceptoLaOferta { get; }
        public List<EtapasCandidato> Candidatos { get; set; }
    }   
}
