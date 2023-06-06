using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningCenter.API.Input;
using LearningCenter.Domain;
using LearningCenter.Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDomain _userDomain;
        private IMapper _mapper;

        public UserController(IUserDomain userDomain,IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/User
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserInput userInput)
        {
            try
            {
                var user = _mapper.Map<UserInput, User>(userInput);


                var isValid = await _userDomain.Login(user);

                if (isValid)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }


        // POST: api/User
        [HttpPost(Name = "Signup")]
        public async Task<IActionResult> Signup([FromBody] UserInput userInput)
        {
            
            var user = _mapper.Map<UserInput, User>(userInput);
            var id = await _userDomain.Signup(user);
            
            if (id > 0)
                return Ok(id.ToString());
            else
                return BadRequest();
        }
        
    }
}
