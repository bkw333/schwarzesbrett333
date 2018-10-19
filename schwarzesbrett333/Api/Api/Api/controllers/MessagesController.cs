using System;
using System.Threading.Tasks;
using Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.controllers
{
    [Route("")]
    public class MessagesController : Controller
    {
        private readonly IHubContext<MessageHub> _messageHubContext;
        private readonly IFeedPostDataRepository _repository;
        private readonly MessageHub _messageHub = new MessageHub();

        public MessagesController(
            IHubContext<MessageHub> messageHubContext,
            IFeedPostDataRepository repository
            )
        {
            _messageHubContext = messageHubContext;
            _repository = repository;
        }

        [HttpGet]
        [Route("/messages")]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _repository.GetAll();
            return Ok(posts);

        }

        [HttpPost]
        [Route("/messages")]
        public async Task<IActionResult> Post([FromBody]Post post)
        {
            var sentMessage = new Post
            {
                Username = post.Username,
                Message = post.Message,
                Datum = DateTime.Now
            };

            await _repository.Add(sentMessage);
            
            try
            {
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
