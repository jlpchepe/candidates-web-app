using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Interfaces
{
    public interface ISimpleWindow
    {
        /// <summary>
        /// Cierra la ventana, en caso de que la pantalla esté cerrada no hace nada
        /// </summary>
        void Close();

        /// <summary>
        /// Evento que ocurre cuando se cierra la ventana
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        /// Muestra en pantalla su contenido
        /// </summary>
        void Show();

        object DataContext { set; }
    }
}
