using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public enum EstatusAcademico
    {
        Egresado,
        Titulado,
        Pasante,
        Estudiante,
        Trunca
    }

        public enum NivelCandidato
    {
        Principiante,
        Junior,
        Intermedio,
        Senior
      
    }

        public enum RolCandidato
    {
        IngenieroDeSoftware,
        Analista,
        AdministradorDeProyecto,
        EspecialistaDeNegocio,
        Tester,
        DataEngineer,
     
    }
        public enum EstatusCandidato
    {
        CitadoParaExamen,
        InteresesAltos,
        Foraneo,
        EnEspera,
        OtraVacante,
        AnalizandoAlCandidato,
        NoLeIntereso,
        VacanteDetenida


    }
        

    /// <summary>
    /// Un candidato a algun puesto
    /// </summary>
    public class Candidato
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        public int AñosDeExperiencia { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; } = DateTime.Now;
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CiudadResidencia { get; set; }
        public decimal SueldoActual { get; set; }
        public decimal SueldoEsperado { get; set; }
        public string Carrera { get; set; }
        public string Universidad { get; set; }

        public decimal NivelDeInglesHablado { get; set; }
        public decimal NivelDeInglesEscrito { get; set; }
        public decimal NivelDeInglesLectura { get; set; }
        public string Cursos { get; set; }
        public string Certificaciones { get; set; }

        //Datos de contacto
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public EstatusAcademico EstatusAcademico { get; set; } = EstatusAcademico.Estudiante;
        public NivelCandidato Nivel { get; set; } = NivelCandidato.Intermedio;
        public string Bolsa { get; set; }
        public DateTime FechaDeContacto { get; set; } = DateTime.Now;
        public string QuienLoContacto { get; set; }
        public RolCandidato Rol { get; set; }
        public DateTime FechaDeExamen { get; set; } = DateTime.Now;
        public DateTime HoraDeExamen { get; set; } = DateTime.Now;
        public decimal CalificacionDelExamen { get; set; }
        public DateTime FechaDeEntrevista { get; set; } = DateTime.Now;
        public decimal PropuestaEconomicaMonto { get; set; }
        public DateTime FechaDeIngresoALaEmpresa { get; set; } = DateTime.Now;
        public EstatusCandidato Estatus { get; set; }
        public string Comentarios { get; set; }
    }
}