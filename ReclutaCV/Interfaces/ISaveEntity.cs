using ReclutaCV.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Interfaces
{
    /// <summary>
    /// Interfaz de una clase que guarda entidades
    /// </summary>
    public interface ISaveEntity
    {
        event ActionEventHandler OnSavedEntity;
    }
}
