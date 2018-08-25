using PropertyChanged;
using ReclutaCV.Base.Window;
using ReclutaCV.Interfaces;
using ReclutaCV.Utils.Commands;
using ReclutaCV.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Base.Edit
{
    [ImplementPropertyChanged]
    public abstract class BaseEditViewModel<TModel, TView, TId> : WindowViewModel<TView>, ISaveEntity
        where TView: ISimpleWindow, new()
    {
        public event ActionEventHandler OnSavedEntity;

        public TModel Model { get; private set; }
        public ICommand GuardarCommand => new SimpleCommand(this.Guardar);
        
        protected abstract Task Insert();
        protected abstract Task Update();
        protected abstract Task<TModel> CargarExistente(TId id);
        protected abstract Task<TModel> CargarNuevo();

        protected bool Editando { get; private set; }

        protected void Guardar()
        {
            if (this.Editando)
            {
                this.Update();
            }
            else
            {
                Insert();
            }

            this.OnSavedEntity?.Invoke();
        }

        public async Task CargarNuevoYAbrirVentana()
        {
            this.Editando = false;
            this.Model = await this.CargarNuevo();
            this.AbrirVentana();
        }

        public async Task CargarExistenteYAbrirVentana(TId id)
        {
            this.Editando = true;
            this.Model = await this.CargarExistente(id);
            this.AbrirVentana();
        }
    }
}
