using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets
                .Include(pet => pet.ownedBy);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id) 
        {
            var pet = _context.Pets.SingleOrDefault(pet => pet.id == id);

            if(pet is null)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpPost]
        public Pet Post(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pet pet)
        {
            // This code will update the pizza and return a result
            if (id != pet.id)
                return BadRequest();
                
            pet = _context.Pets.SingleOrDefault(pet => pet.id == id);

            if(pet is null)
                return NotFound();
        
            _context.Update(pet);           
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
            if(pet is null)
            {
                return NotFound();
            }

            _context.Remove(pet);

            _context.SaveChanges();

            return Ok();
        }


        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
