using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Context;
using WebApiDemo.Dto;
using WebApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class PersonController : ControllerBase
    {
        private readonly CRUDContext _crud;

        public PersonController(CRUDContext crud)
        {
            _crud = crud;
        }

        
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {

            return _crud.persons;
        }


        

        // GET api/<PersonController>/5
        [HttpGet("{id}")]

        public Person Get(int id)
        {
             
            return _crud.persons.SingleOrDefault(x => x.id == id);
            
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post(Person person)
        {
            _crud.persons.Add(person);
            _crud.SaveChanges();
            return Ok(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Person person)
        {

            _crud.persons.Update(person);
            _crud.SaveChanges();
            return Ok(person);
        }

        // PATCH api/<PersonController>/5
        [HttpPatch]
        public IActionResult Patch(PersonDto persondto)
        {
            var entity = _crud.persons.FirstOrDefault(x => x.id == persondto.id);

            if (entity == null)
            {
                return NotFound();
            }
            
            if (!string.IsNullOrWhiteSpace(persondto.name))
                entity.name = persondto.name;

            if (persondto.age>0)
                entity.age = persondto.age;

            if (persondto.mobile>0) 
             entity.mobile = persondto.mobile;
            
            if (!string.IsNullOrWhiteSpace(persondto.address))
             entity.address = persondto.address;


            _crud.persons.Update(entity);
            _crud.SaveChanges();

            
            
            return Ok(entity);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _crud.persons.FirstOrDefault(x => x.id ==id);
            if(item!=null)
            {
                _crud.persons.Remove(item);
                _crud.SaveChanges();
            }
             
        }
    }
}
