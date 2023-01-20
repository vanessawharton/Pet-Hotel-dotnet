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

        // [HttpPost]
        // public PetOwner Post(PetOwner petOwner)
        // {
        //     _context.Add(petOwner);

        //     _context.SaveChanges();

        //     return petOwner;
        // }
        
        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id)
        // {
        //     var owner = PetOwnerService.Get(id);

        //     if(owner is null)
        //         return NotFound();
            
        //     PetOwnerService.Delete(id);

        //     return NoContent();
        // }
        
    }
}
