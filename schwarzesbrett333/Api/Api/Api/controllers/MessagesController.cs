using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace Api.controllers
{
    [Route("")]
    public class MessagesController : Controller
    {
        private readonly IHubContext<MessageHub> _messageHubContext;
        private readonly MessageHub _messageHub = new MessageHub();

        public MessagesController(IHubContext<MessageHub> messageHubContext)
        {
            _messageHubContext = messageHubContext;
        }

        [HttpGet]
        [Route("/messages")]
        public async Task<IActionResult> Get()
        {
            return Ok(new[]
            {
                new Post
                {
                    Username = "Peter",
                    Message = "Das ist eine Testnachricht!"
                },
                new Post
                {
                    Username = "Ralf",
                    Message = "Das ist eine zweite Testnachricht!"
                },
                new Post
                {
                    Username = "Anton",
                    Message = "Wow! Knorke WG!"
                }
            });
        }

        [HttpPost]
        [Route("/messages")]
        public async Task<IActionResult> Post([FromBody]Post post)
        {
            var sentMessage = new Post
            {
                Username = post.Username,
                Message = post.Message
            };

            try
            {
                //await _messageHub.Send(sentMessage);

                await _messageHubContext.Clients.All.SendAsync("Send", sentMessage);
            }
            catch (Exception e)
            {

                Console.Write(e.ToString());
            }

            return Ok();
        }
    }
}