using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week03.Data;
using Week03.Models;

namespace Week03.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreatePet")]
        public async Task<IActionResult> CreatePet(Pet pet)
        {
            if(pet == null)
            {
                return BadRequest();
            }

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("GetPetList")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetList()
        {
            var petList = await _context.Pets.ToListAsync();
            return Ok(petList);
        }

        [HttpGet("GetPet/{id}")]
        public async Task<IActionResult> GetPet(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(pet);

        }

        [HttpPut("UpdatePet/{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pet pet)
        {
            if(id != pet.Id && pet == null)
            {
                return BadRequest();
            }

            var existPet = await _context.Pets.FindAsync(id);

            if(existPet == null)
            {
                return BadRequest();
            }

            existPet.Name = pet.Name;
            existPet.Age = pet.Age;
            existPet.Type = pet.Type;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}