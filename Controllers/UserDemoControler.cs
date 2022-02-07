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

        public UserDemoControler(IUserRepository userRepository)
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
        public async Task<ActionResult< UserDemo>> GetUserById(int id)
        {
            try
            {
                var result=await _userRepository.GetUserById(id);

                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur l'or de l'extraction des données");
                throw;
            }
        }

        // POST api/<UserDemo>
        [HttpPost]
        public async Task<ActionResult<UserDemo>> AddUser(UserDemo userDemo)
        {
            try
            {
                if (userDemo==null)
                {
                    return BadRequest();
                }

                var newUser= await _userRepository.AddUser(userDemo);

                return CreatedAtAction(nameof(GetUserById), new {id=userDemo.Id},newUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de l'ajout de l'utilisateur");
            }
        }

        // PUT api/<UserDemo>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDemo>> UpdateUser(int id, UserDemo userDemo)
        {
            try
            {
                if (id!=userDemo.Id)
                {
                    return BadRequest("l'identifiant ne correspond pas à l'utilisateur fournie");
                }
                var userToUpdate = await _userRepository.GetUserById(id);
                if (userToUpdate == null)
                {
                    return NotFound($"l'employer avec l'identifiant {id} n'existe pas");
                }
                return await _userRepository.UpdateUser(userDemo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur de Mise à jour des données");
            }
        }

        // DELETE api/<UserDemo>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var userTodelete = await _userRepository.GetUserById(id);
                if(userTodelete == null)
                {
                    return NotFound($"l'employer avec l'ID {id} n'existe pas");
                }
                await _userRepository.DeleteUser(id);
                return Ok($"Employer avec l'ID {id} Supprimer");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur l'or de l'extraction des données");
                throw;
            }
        }
    }
}
