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
    public class ActivityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActivityController(ApplicationDbContext context)
        {
            _context = context;
        }

    [HttpPost]
    public async Task<ActionResult<Activity>> PostActivity(Activity activity)
    {
        _context.Avtivities.Add(activity);
        await _context.SaveChangesAsync();

            return Ok(activity);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivities(int id)
    {
        var activities = await _context.Avtivities
            .Where(a => a.Id == id)
            .ToListAsync();

        if (!activities.Any())
        {
            return NotFound();
        }

        return activities;
    }
    }
}