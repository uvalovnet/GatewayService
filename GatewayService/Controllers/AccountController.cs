using Entities.Interfaces;
using Entities.Responses.Account;
using Microsoft.AspNetCore.Mvc;
using static Confluent.Kafka.ConfigPropertyNames;

namespace GatewayService.Controllers
{
    [ApiController]
    [Route("")]
    public class AccountController : Controller
    {
        ISender _sender;
        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<User>> Auth([FromBody] UserRegDTO reuqest)
        {
            try
            {
                return new User() { NickName = "Vadim"};
            }
            catch(Exception ex)
            {
               throw ex;
            }
        }
        [HttpPost("reg")]
        public async Task<ActionResult<bool>> Reg([FromBody] UserRegDTO collection)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class UserRegDTO
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
