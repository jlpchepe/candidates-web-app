using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReclutaCV.Utils.Commands
{
    public class AsyncCommand : ICommand
    {
        /// <summary>
        /// Constructor para un comando que siempre puede ejecutarse
        /// </summary>
        /// <param name="accionAEjecutar"></param>
        public AsyncCommand(
            Func<Task> accionAEjecutar
        ) : this(accionAEjecutar, () => true)
        { }

        public AsyncCommand(
            Func<Task> accionAEjecutar,
            Func<bool> puedeEjecutar
        )
        {
            this.puedeEjecutar = puedeEjecutar;
            this.accionAEjecutar = accionAEjecutar;


        }
        private readonly Func<Task> accionAEjecutar;
        private readonly Func<bool> puedeEjecutar;
        private bool TaskIsBeingExecuted { get; set; } = false;

        public bool CanExecute(object parameter)
        {
            return !TaskIsBeingExecuted && this.puedeEjecutar();
        }

        public async void Execute(object parameter)
        {
            TaskIsBeingExecuted = true;
            try
            {
                await this.accionAEjecutar();
            }
            finally
            {
                TaskIsBeingExecuted = false;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
