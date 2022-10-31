using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfoAPI.Models;
using InfoAPI.Services;

namespace InfoAPI.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
               
               
        private readonly IPerson _personService;

        public PersonController(IPerson personService)
        {
            _personService = personService;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        // {
        //     return await _context.Persons.All;
        // }

        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return _personService.getAllPersons();
        }

    }
}
