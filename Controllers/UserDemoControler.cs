using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProject.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserDemoControler : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserDemoControler(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        // GET: api/<UserDemo>
        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            try
            {
                return Ok(await _userRepository.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur l'or de l'extraction des données");
                throw;
            }
        }

        // GET api/<UserDemo>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserDemo>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserDemo>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserDemo>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
