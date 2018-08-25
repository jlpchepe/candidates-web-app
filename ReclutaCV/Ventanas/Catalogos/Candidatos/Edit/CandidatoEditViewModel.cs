using PropertyChanged;
using ReclutaCV.Base.Edit;
using ReclutaCV.Base.Window;
using ReclutaCV.Candidatos.List;
using ReclutaCV.Interfaces;
using ReclutaCV.Utils.Commands;
using ReclutaCV.Utils.Eventos;
using ReclutaCVData;
using ReclutaCVData.Entidades;
using ReclutaCVLogic.Servicios;
using ReclutaCVLogic.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
