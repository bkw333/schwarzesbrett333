using System;
using System.Linq;
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
        private readonly ISpamCheck _spamCheck;
        private readonly MessageHub _messageHub = new MessageHub();

        public MessagesController(
            IHubContext<MessageHub> messageHubContext,
            IFeedPostDataRepository repository,
            ISpamCheck spamCheck
            )
        {
            _messageHubContext = messageHubContext;
            _repository = repository;
            _spamCheck = spamCheck;
        }

        [HttpGet]
        [Route("/messages")]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _repository.GetAll();
            return Ok(posts.OrderByDescending(c => c.Id));

        }

        [HttpPost]
        [Route("/messages")]
        public async Task<IActionResult> Post([FromBody]Post post)
        {
            var sentMessage = new Post
            {
                Username = post.Username,
                Message = post.Message,
                Datum = DateTime.Now.AddHours(2)
            };

            if (!await _spamCheck.IsSpam(sentMessage))
            {
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

            return StatusCode(429);
        }

       
    }
}
