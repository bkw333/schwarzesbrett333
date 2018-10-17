using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Api.controllers
{
    [Route("")]
    public class MessagesController : Controller
    {
        [HttpGet]
        [Route("")]
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
                }
            });
        }
    }
}