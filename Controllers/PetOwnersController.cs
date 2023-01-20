using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() 
        {
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if(petOwner is null)
            {
                return NotFound();
            }
            return petOwner;
        }

        [HttpPost]
        public PetOwner Post(PetOwner petOwner)
        {
            _context.Add(petOwner);

            _context.SaveChanges();

            return petOwner;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PetOwner petOwner)
        {
            // This code will update the pizza and return a result
            if (id != petOwner.id)
                return BadRequest();
                
            petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if(petOwner is null)
                return NotFound();
        
            _context.Update(petOwner);  

            _context.SaveChanges();         
        
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if(petOwner is null)
                return NotFound();
            
            _context.Remove(id);

            _context.SaveChanges();

            return NoContent();
        }
        
    }
}
