using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCenter.Infraestructure;
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

        public TutorialController(ITutorialInfraestructure tutorialInfraestructura)
        {
            _tutorialInfraestructura = tutorialInfraestructura;
        }
        
        
        // GET: api/Tutorial
        [HttpGet]
        public List<string> Get()
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
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
