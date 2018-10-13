using ReclutaCV.Utils.Commands;
using System.Windows;
using System.Windows.Input;

namespace ReclutaCV.Base.Windows
{
    public class WindowViewModel<TView>
        where TView: Window, new()
    {
        private TView Ventana { get; set; }

        public void AbrirVentana()
        {
            if(this.Ventana == null)
            {
                this.Ventana = new TView
                {
                    DataContext = this
                };
            }

            this.Ventana.Show();
        }

        public void CerrarVentana()
        {
            this.Ventana?.Close();
        }

        public ICommand CerrarVentanaCommand => new SimpleCommand(this.CerrarVentana);
    }
}