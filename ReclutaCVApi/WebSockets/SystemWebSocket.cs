using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppPersistence.Dtos;
using AppPersistence.Events;
using AppPersistence.Handlers;
using Microsoft.AspNetCore.SignalR;

namespace ReclutaCVApi.WebSockets
{
    /// <summary>
    /// Canal de websocket para enviar la información de todo tipo de la aplicación web, esto puede incluir:
    /// - Cambio de configuraciones
    /// - Notificaciones
    /// - Baja de usuarios
    /// Todo, excepto 
    /// </summary>
    public class SystemWebSocket :
        BaseWebSocket,
        EventSubscriber<NotificationCreated>,
        EventSubscriber<NotificationRead>,
        EventSubscriber<UserDisabled>
    {
        private Task SendSystemEventToUser(SystemEventType systemEventType, object systemEvent, int userId) =>
            SendEventToUser(userId, new SystemEvent(systemEventType, systemEvent));

        private Task SendSystemEventToAll(SystemEventType systemEventType, object systemEvent) => 
            SendEventToAll(new SystemEvent(systemEventType, systemEvent));

        Task EventSubscriber<NotificationCreated>.HandleEvent(
            NotificationCreated publishedEvent
        ) => SendSystemEventToUser(SystemEventType.NotificationCreated, publishedEvent, publishedEvent.UserId);

        Task EventSubscriber<NotificationRead>.HandleEvent(
            NotificationRead publishedEvent
        ) => SendSystemEventToAll(SystemEventType.NotificationRead, publishedEvent);

        Task EventSubscriber<UserDisabled>.HandleEvent(
            UserDisabled publishedEvent
        ) => SendSystemEventToUser(SystemEventType.UserDisabled, publishedEvent, publishedEvent.UserId);
    }
}