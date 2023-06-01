using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCenter.API.Input;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        //Inyeccion
        private ITutorialInfraestructure _tutorialInfraestructura;
        private ITutorialDomain _tutorialDomain;

        public TutorialController(ITutorialInfraestructure tutorialInfraestructura, ITutorialDomain tutorialDomain)
        {
            _tutorialInfraestructura = tutorialInfraestructura;
            _tutorialDomain = tutorialDomain;
        }
        
        
        
        // GET: api/Tutorial
        [HttpGet]
        public async Task<List<Tutorial>> Get()
        {
            //TutorialOracleInfraestructure tutorialOracleInfraestructure = new TutorialOracleInfraestructure();
            //return tutorialOracleInfraestructure.GetAll();

            //TutorialSQLInfraestructure tutorialSqlInfraestructure = new TutorialSQLInfraestructure();
            //return tutorialSqlInfraestructure.GetAll();

            return await _tutorialInfraestructura.GetAll();
        }
        
        
        [HttpGet("GetBy/{name}")]

        public List<Tutorial> Get(string name)
        {
            return _tutorialInfraestructura.GetByName(name);
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public Tutorial Get(int id)
        {
           return _tutorialInfraestructura.GetById(id);
        }

        // POST: api/Tutorial
        [HttpPost]
        public async Task PostAsync([FromBody] TutorialInput input)
        {
            if (ModelState.IsValid){
                
                //Temporal
                Tutorial tutorial = new Tutorial()
                {
                    Name = input.Name,
                    Description = input.Description,
                    MaxLenght = input.MaxLenght
                };
                
                await _tutorialDomain.CreateAsync(tutorial);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TutorialInput input)
        {
            if (ModelState.IsValid)
            {
                Tutorial tutorial = new Tutorial()
                {
                    Name = input.Name,
                    Description = input.Description
                };
                _tutorialDomain.Update(id, tutorial);
            }
            else
            {
                StatusCode(400);
            }
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tutorialDomain.Delete(id);
        }
    }
}
