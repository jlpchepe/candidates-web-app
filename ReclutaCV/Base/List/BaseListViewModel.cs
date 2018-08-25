using PropertyChanged;
using ReclutaCV.Candidatos.Edit;
using ReclutaCV.Candidatos.List;
using ReclutaCV.Interfaces;
using ReclutaCV.Utils.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReclutaCV.Base.List
{
    [ImplementPropertyChanged]
    public abstract class BaseListViewModel<TItem, TView, TEditViewModel>
        where TView : ISimpleWindow, new()
        where TItem : class
        where TEditViewModel : ISaveEntity
    {
        public BaseListViewModel()
        {
        }

        public IReadOnlyCollection<TItem> Items { get; private set; }
        public TItem Seleccionado { get; set; }
        private bool TieneSeleccionado => this.Seleccionado != null;
        
        protected abstract Task<IReadOnlyCollection<TItem>> ObtenerItems();
        protected abstract Task OnAgregar();
        protected abstract Task OnBorrar(TItem item);
        protected abstract Task OnEditar(TItem item);

        public void MostrarVentana()
        {
            var ventana = new TView
            {
                DataContext = this
            };
            ventana.Show();
        }

        public ICommand Agregar => new AsyncCommand(
            () => this.OnAgregar()
        );
        public ICommand Editar => new AsyncCommand(
            () => this.OnEditar(this.Seleccionado),
            () => TieneSeleccionado
        );
        public ICommand Borrar => new AsyncCommand(
            async () => {
                await this.OnBorrar(this.Seleccionado);
                await this.RefrescarItems();
            },
            () => TieneSeleccionado
        );

        public async Task RefrescarItems()
        {
            //Cargamos los candidatos desde la base de datos
            this.Items = await this.ObtenerItems();
        }

        protected async void RefrescarItemsSync()
        {
            await this.RefrescarItems();
        }
    }
}
