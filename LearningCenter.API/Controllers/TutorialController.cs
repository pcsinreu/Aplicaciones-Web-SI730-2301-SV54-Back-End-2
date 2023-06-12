using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningCenter.API.Filter;
using LearningCenter.API.Input;
using LearningCenter.API.Response;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{
  
    [Authorize("admin,account")]
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        //Inyeccion
        private ITutorialInfraestructure _tutorialInfraestructura;
        private ITutorialDomain _tutorialDomain;
        private IMapper _mapper;

        public TutorialController(ITutorialInfraestructure tutorialInfraestructura, ITutorialDomain tutorialDomain,IMapper mapper)
        {
            _tutorialInfraestructura = tutorialInfraestructura;
            _tutorialDomain = tutorialDomain;
            _mapper = mapper;
        }
        
        // GET: api/Tutorial
        [Authorize("admin")]
        [HttpGet]
        public async Task<List<TutorialResponse>> Get()
        {
            //TutorialOracleInfraestructure tutorialOracleInfraestructure = new TutorialOracleInfraestructure();
            //return tutorialOracleInfraestructure.GetAll();

            //TutorialSQLInfraestructure tutorialSqlInfraestructure = new TutorialSQLInfraestructure();
            //return tutorialSqlInfraestructure.GetAll();
            
            var result = await _tutorialInfraestructura.GetAll();

           /* List<TutorialResponse> list = new List<TutorialResponse>();
            foreach (var tutorial in result)
            {
                list.Add(new TutorialResponse()
                {
                    Name = tutorial.Name,
                    Description = tutorial.Description,
                    Id = tutorial.Id
                });
                
            }*/

           var list =  _mapper.Map<List<Tutorial>, List<TutorialResponse>>(result);

            return list;

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
        public async Task<IActionResult> PostAsync([FromBody] TutorialInput input)
        {
            if (ModelState.IsValid)
            {
                var tutorial = _mapper.Map<TutorialInput, Tutorial>(input);
                var result = await _tutorialDomain.CreateAsync(tutorial);
                
                return  result ? StatusCode(201) : StatusCode(500);
            }
            else
            {
               return StatusCode(400);
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
