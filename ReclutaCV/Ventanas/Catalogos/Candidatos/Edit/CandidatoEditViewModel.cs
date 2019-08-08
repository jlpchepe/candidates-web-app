using PropertyChanged;
using ReclutaCV.Base.Edit;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using ReclutaCVLogic.Utils.Helpers;
using System;
using System.Threading.Tasks;

namespace ReclutaCV.Candidatos.Edit
{
    

    /// <summary>
    /// Ventana para edición de candidatos
    /// </summary>
    [ImplementPropertyChanged]
    public class CandidatoEditViewModel : BaseEditViewModel<Candidato, CandidatoEditView, int>
    {
        public CandidatoEditViewModel(
            CandidatoService candidatoService
        )
        {
            this.candidatoService = candidatoService;
        }

        private readonly CandidatoService candidatoService;

        public decimal ObtenerCalificacion(
            Func<Candidato, int?> aciertosSelector,
            Func<Candidato, int?> totalReactivosSelector
        )
        {
            if(this.Model == null)
            {
                return 0;
            }

            var aciertos = aciertosSelector(this.Model);
            var totalReactivos = totalReactivosSelector(this.Model);

            return aciertos != null && totalReactivos > 0 ? 
                (aciertos.Value / (decimal)totalReactivos.Value) :
                0; 
        }

        [DependsOn(nameof(Candidato.ExamenProgramacionAciertos), nameof(Candidato.ExamenProgramacionTotalReactivos))]
        public decimal ExamenProgramacionCalificacion => ObtenerCalificacion(m => m.ExamenProgramacionAciertos, m => m.ExamenProgramacionTotalReactivos);
        [DependsOn(nameof(Candidato.ExamenAnalistaTeoricoAciertos), nameof(Candidato.ExamenAnalistaTeoricoTotalReactivos))]
        public decimal ExamenAnalistaTeoricoCalificacion => ObtenerCalificacion(m => m.ExamenAnalistaTeoricoAciertos, m => m.ExamenAnalistaTeoricoTotalReactivos);
        [DependsOn(nameof(Candidato.ExamenAnalistaPracticoAciertos), nameof(Candidato.ExamenAnalistaPracticoTotalReactivos))]
        public decimal ExamenAnalistaPracticoCalificacion => ObtenerCalificacion(m => m.ExamenAnalistaPracticoAciertos, m => m.ExamenAnalistaPracticoTotalReactivos);
        [DependsOn(nameof(Candidato.ExamenIngenieroPruebasTeoricoAciertos), nameof(Candidato.ExamenIngenieroPruebasTeoricoTotalReactivos))]
        public decimal ExamenIngenieroPruebasTeoricoCalificacion => ObtenerCalificacion(m => m.ExamenIngenieroPruebasTeoricoAciertos, m => m.ExamenIngenieroPruebasTeoricoTotalReactivos);
        [DependsOn(nameof(Candidato.ExamenAdministradorProyectoAciertos), nameof(Candidato.ExamenAdministradorProyectoTotalReactivos))]
        public decimal ExamenAdministradorProyectoCalificacion => ObtenerCalificacion(m => m.ExamenAdministradorProyectoAciertos, m => m.ExamenAdministradorProyectoTotalReactivos);
        [DependsOn(nameof(Candidato.ExamenPracticoSoporteBdAciertos), nameof(Candidato.ExamenPracticoSoporteBdTotalReactivos))]
        public decimal ExamenPracticoSoporteBdCalificacion => ObtenerCalificacion(m => m.ExamenPracticoSoporteBdAciertos, m => m.ExamenPracticoSoporteBdTotalReactivos);
        
        protected override Task Insert() => 
            candidatoService.Insert(this.Model);

        protected override Task Update() => 
            candidatoService.Update(this.Model);

        protected override Task<Candidato> CargarExistente(int id) => 
            this.candidatoService.FindById(id, entity => entity);

        protected override Task<Candidato> CargarNuevo() =>
            Task.FromResult(new Candidato());
    }
}
