using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using AppPersistence.Dtos;
using AppPersistence.Events;
using AppPersistence.Handlers;
using Microsoft.AspNetCore.SignalR;

namespace ReclutaCVApi.WebSockets
{
    /// <summary>
    /// Canal de websocket para enviar la información de una orden de trabajo a la aplicación web
    /// </summary>
    public class WorkOrderWebSocket : 
        BaseWebSocket, 
        EventSubscriber<WorkOrderActivitiesAdded>,
        EventSubscriber<WorkOrderActivityDeleted>,
        EventSubscriber<WorkOrderActivityFinished>,
        EventSubscriber<WorkOrderActivityPaused>,
        EventSubscriber<WorkOrderActivityStarted>,
        EventSubscriber<WorkOrderActivityStopped>,
        EventSubscriber<WorkOrderActivityTimeChanged>,
        EventSubscriber<WorkOrderActivityOperatorChanged>,
        EventSubscriber<WorkOrderDeleted>,
        EventSubscriber<WorkOrderFinished>,
        EventSubscriber<WorkOrderSaved>,
        EventSubscriber<WorkOrderActivitiesOrderChanged>
    {
        /// <summary>
        /// Envía el mensaje a los clientes del websocket
        /// </summary>
        /// <param name="event"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        private async Task NotifyEvent(
            object @event,
            WorkOrderEventType eventType
        ) => await SendEventToAll(
                new WorkOrderEvent(
                    eventType,
                    @event
                )
            );

        Task EventSubscriber<WorkOrderActivitiesAdded>.HandleEvent(WorkOrderActivitiesAdded publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivitiesAdded);
        Task EventSubscriber<WorkOrderActivityDeleted>.HandleEvent(WorkOrderActivityDeleted publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityDeleted);
        Task EventSubscriber<WorkOrderActivityFinished>.HandleEvent(WorkOrderActivityFinished publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityFinished);
        Task EventSubscriber<WorkOrderActivityPaused>.HandleEvent(WorkOrderActivityPaused publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityPaused);
        Task EventSubscriber<WorkOrderActivityStarted>.HandleEvent(WorkOrderActivityStarted publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityStarted);
        Task EventSubscriber<WorkOrderActivityStopped>.HandleEvent(WorkOrderActivityStopped publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityStopped);
        Task EventSubscriber<WorkOrderActivityTimeChanged>.HandleEvent(WorkOrderActivityTimeChanged publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityTimeChanged);
        Task EventSubscriber<WorkOrderFinished>.HandleEvent(WorkOrderFinished publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderFinished);
        Task EventSubscriber<WorkOrderSaved>.HandleEvent(WorkOrderSaved publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderSaved);
        Task EventSubscriber<WorkOrderDeleted>.HandleEvent(WorkOrderDeleted publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderDeleted);
        Task EventSubscriber<WorkOrderActivityOperatorChanged>.HandleEvent(WorkOrderActivityOperatorChanged publishedEvent) => 
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivityOperatorChanged);
        Task EventSubscriber<WorkOrderActivitiesOrderChanged>.HandleEvent(WorkOrderActivitiesOrderChanged publishedEvent) =>
            NotifyEvent(publishedEvent, WorkOrderEventType.WorkOrderActivitiesOrderChanged);
    }
}