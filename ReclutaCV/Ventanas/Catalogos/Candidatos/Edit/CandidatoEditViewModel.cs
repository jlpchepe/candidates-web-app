using PropertyChanged;
using ReclutaCV.Base.Edit;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using ReclutaCVLogic.Utils.Helpers;
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

        protected override Task Insert()
        {
            this.candidatoService.Insert(this.Model);
            return TaskHelper.CreateEmptyTask();
        }
        protected override Task Update()
        {
            this.candidatoService.Update(this.Model);
            return TaskHelper.CreateEmptyTask();
        }
        protected override Task<Candidato> CargarExistente(int id)
        {
            return Task.FromResult(this.candidatoService.FindById(id));
        }

        protected override Task<Candidato> CargarNuevo()
        {
            return Task.FromResult(new Candidato());
        }
    }
}
