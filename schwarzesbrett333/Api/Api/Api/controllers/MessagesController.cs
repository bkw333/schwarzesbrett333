using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Api.controllers
{
    [Route("")]
    public class MessagesController : Controller
    {

        [HttpGet]
        [Route("/messages")]
        public async Task<IActionResult> Get()
        {
            return Ok(new[]
            {
                new
                {
                    Username = "Peter",
                    Message = "Das ist eine Testnachricht!"
                },
                new
                {
                    Username = "Ralf",
                    Message = "Das ist eine zweite Testnachricht!"
                },
                new
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
            var sentMessage = new Post();
            sentMessage.Username = post.Username;
            sentMessage.Message = post.Message;


            return Ok();
        }
    }
}