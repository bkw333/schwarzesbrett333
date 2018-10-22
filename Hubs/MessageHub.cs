using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class MessageHub : Hub
    {
        public Task Send(Post data)
        {
            return Clients.All.SendAsync("Send", data);
        }
    }
}
