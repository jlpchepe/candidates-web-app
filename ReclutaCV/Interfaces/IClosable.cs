using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Interfaces
{
    public interface IClosable
    {
        /// <summary>
        /// Cierra la ventana, en caso de que la pantalla esté cerrada no hace nada
        /// </summary>
        void Close();
    }
}
