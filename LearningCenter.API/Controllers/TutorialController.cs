using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public List<Tutorial> Get()
        {
            //TutorialOracleInfraestructure tutorialOracleInfraestructure = new TutorialOracleInfraestructure();
            //return tutorialOracleInfraestructure.GetAll();

            //TutorialSQLInfraestructure tutorialSqlInfraestructure = new TutorialSQLInfraestructure();
            //return tutorialSqlInfraestructure.GetAll();

            return _tutorialInfraestructura.GetAll();
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tutorial
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _tutorialDomain.Create(value);
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _tutorialDomain.Update(id, value);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tutorialDomain.Delete(id);
        }
    }
}
