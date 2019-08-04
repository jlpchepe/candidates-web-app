using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ReclutaCVApi.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ReclutaCVApi.WebSockets
{
    /// <summary>
    /// Clase de la cual heredan los web sockets de la aplicación
    /// </summary>
    public class BaseWebSocket : Hub
    {
        /// <summary>
        /// Lista de conexiones que se ira administrando dependiendo de los eventos del canal 
        /// </summary>
        private readonly static Dictionary<int, HashSet<string>> userConnections = new Dictionary<int, HashSet<string>>();
        private readonly static ISet<string> anonymousConnections = new HashSet<string>();

        private ISet<string> GetContextAuthenticatedUserConnections() =>
            GetContextUserConnections(AuthenticationHelper.GetAuthenticatedUserId(Context.User));

        private ISet<string> GetContextUserConnections(int? userId)
        {
            if(userId == null) { return anonymousConnections; }

            if (!userConnections.ContainsKey(userId.Value))
            {
                userConnections.Add(userId.Value, new HashSet<string>());
            }
            return userConnections[userId.Value];
        }

        /// <summary>
        /// Remueve una conexión
        /// </summary>
        /// <param name="connectionId"></param>
        private void RemoveConnection(string connectionId)
        {
            anonymousConnections.Remove(connectionId);
            foreach (var user in userConnections)
            {
                user.Value.Remove(connectionId);
            }
        }

        /// <summary>
        /// Envía el evento a los clientes indicados
        /// </summary>
        /// <param name="clientsToSendEvent"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        private Task SendEvent(
            IClientProxy clientsToSendEvent,
            object @event
        ) => clientsToSendEvent.SendAsync("SendEvent", @event);

        /// <summary>
        /// Envía un evento al usuario con ID indicado, solo si esta conectado al web socket
        /// </summary>
        /// <param name="userId">ID del usuario al que se notificará</param>
        /// <param name="event"></param>
        protected Task SendEventToUser(
            int userId,
            object @event
        ) => SendEvent(
                Clients.Clients(GetContextUserConnections(userId).ToList()), 
                @event
            );

        /// <summary>
        /// Método que envía un evento a todos los conectados al web socket
        /// </summary>
        protected Task SendEventToAll(object @event) => 
            SendEvent(
                Clients.All, 
                @event
            );

        public override Task OnConnectedAsync()
        {
            GetContextAuthenticatedUserConnections().Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            RemoveConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
