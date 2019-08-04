using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.WebSockets
{
    /// <summary>
    /// Tipos de eventos notificationes
    /// </summary>
    public enum SystemEventType
    {
        /// <summary>
        /// Evento que indica que se terminó de consultar las notificación actuales no leídas
        /// </summary>
        NotificationQueried,
        /// <summary>
        /// Evento que indica que se creó una notificación
        /// </summary>
        NotificationCreated,
        /// <summary>
        /// Evento que indicad que se leyó una notificación
        /// </summary>
        NotificationRead,
        /// <summary>
        /// Evento que indica que un usuario fue deshabilitado
        /// </summary>
        UserDisabled
    }

    /// <summary>
    /// Eventos de notificación
    /// </summary>
    public class SystemEvent
    {
        public SystemEvent(
            SystemEventType type, 
            object @event
        )
        {
            Type = type;
            Event = @event;
        }

        public SystemEventType Type { get; set; }

        /// <summary>
        /// Evento que fue lanzado, su tipo es determinado por el campo <see cref="WorkOrderEvent.Type"/>
        /// </summary>
        public object Event { get; set; }
    }
}
