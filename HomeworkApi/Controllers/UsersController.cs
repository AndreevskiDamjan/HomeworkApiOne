using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAllUsernames()
        {
            return Ok(StaticDb.Usernames);
        }

        [HttpGet(("{index}"))]
        public ActionResult<List<string>> GetUsernameByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest();
                }

                if (index >= StaticDb.Usernames.Count)
                {
                    return NotFound($"There is no username with an index:{index} \n Try another one.");
                }
                

                return Ok(StaticDb.Usernames[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
