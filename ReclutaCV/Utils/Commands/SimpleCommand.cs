using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Utils.Commands
{
    /// <summary>
    /// Un comando simple que tiene una acción a ejecutar y una condición para ejecutarse
    /// </summary>
    public class SimpleCommand : ICommand
    {
        /// <summary>
        /// Constructor para un comando que siempre puede ejecutarse
        /// </summary>
        /// <param name="accionAEjecutar"></param>
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

        public bool CanExecute(object parameter)
        {
            return this.puedeEjecutar();
        }

        public void Execute(object parameter)
        {
            this.accionAEjecutar();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
