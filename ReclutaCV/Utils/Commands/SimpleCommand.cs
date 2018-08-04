using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Utils.Commands
{
    public class SimpleCommand : ICommand
    {
        public SimpleCommand(
            Action accionAEjecutar
        ) : this(accionAEjecutar, () => true)
        {}

        public SimpleCommand(
            Action accionAEjecutar,
            Func<bool> puedeEjecutar
        )
        {
            this.puedeEjecutar = puedeEjecutar;
            this.accionAEjecutar = accionAEjecutar;

        }
        private readonly Action accionAEjecutar;
        private readonly Func<bool> puedeEjecutar;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.puedeEjecutar();
        }

        public void Execute(object parameter)
        {
            this.accionAEjecutar();
        }
    }
}
