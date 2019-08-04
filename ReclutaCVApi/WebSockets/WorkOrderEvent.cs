using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.WebSockets
{
    /// <summary>
    /// Tipos de eventos de ordenes de trabajo
    /// </summary>
    public enum WorkOrderEventType
    {
        WorkOrderQueried,
        WorkOrderSaved,
        WorkOrderDeleted,
        WorkOrderFinished,
        WorkOrderActivitiesAdded,
        WorkOrderActivityDeleted,
        WorkOrderActivityFinished,
        WorkOrderActivityPaused,
        WorkOrderActivityStarted,
        WorkOrderActivityStopped,
        WorkOrderActivityTimeChanged,
        WorkOrderActivityOperatorChanged,
        WorkOrderActivitiesOrderChanged
    }

    /// <summary>
    /// Un evento relacionado con ordenes de trabajo
    /// </summary>
    public class WorkOrderEvent
    {
        public WorkOrderEvent(WorkOrderEventType type, object @event)
        {
            Type = type;
            Event = @event;
        }

        public WorkOrderEventType Type { get; set; }

        /// <summary>
        /// Evento que fue lanzado, su tipo es determinado por el campo <see cref="WorkOrderEvent.Type"/>
        /// </summary>
        public object Event { get; set; }
    }
}
