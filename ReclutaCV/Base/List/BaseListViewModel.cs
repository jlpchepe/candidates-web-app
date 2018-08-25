using ReclutaCV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Base.List
{
    internal class BaseListViewModel<TItem, TView, >
        where TView: ISimpleWindow, new()
        where TItem : class
    {
        public()

        public List<TItem> Items { get; private set; }
        public TItem Seleccionado { get; set; }
        private bool TieneSeleccionado => this.Seleccionado != null;

        private readonly Func<CandidatoEditViewModel> candidatoEditViewModelFactory;

        private CandidatoEditViewModel ObtenerVentanaEdicion()
        {
            var ventanaEdicion = this.candidatoEditViewModelFactory();

            ventanaEdicion.OnSavedEntity += () => this.RefrescarCandidatos();

            return ventanaEdicion;
        }

        public void MostrarVentana()
        {
            var ventana = new CandidatoListView
            {
                DataContext = this
            };
            ventana.InitializeComponent();
            ventana.Show();
        }

        public ICommand Agregar => new SimpleCommand(this.ObtenerVentanaEdicion().CargarNuevoYAbrirVentana);
        public ICommand Editar => new SimpleCommand(() => this.ObtenerVentanaEdicion().CargarExistenteYAbrirVentana(this.Seleccionado.Id), () => TieneSeleccionado);
        public ICommand Borrar => new SimpleCommand(() => {
            this.candidatoService.Delete(this.Seleccionado.Id);
            this.RefrescarCandidatos();
        }, () => TieneSeleccionado);

        public void RefrescarCandidatos()
        {
            //Cargamos los candidatos desde la base de datos
            this.Items = this.candidatoService.FindAll();
        }
    }
}
