using ReclutaCV.Interfaces;
using ReclutaCV.Utils.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Base.Window
{
    public class WindowViewModel<TView>
        where TView: ISimpleWindow, new()
    {
        private TView Ventana { get; set; }

        public void AbrirVentana()
        {
            this.Ventana = new TView
            {
                DataContext = this
            };
            
            this.Ventana.Show();
        }

        public void CerrarVentana()
        {
            this.Ventana?.Close();
        }

        public ICommand CerrarVentanaCommand => new SimpleCommand(this.CerrarVentana);
    }
}
