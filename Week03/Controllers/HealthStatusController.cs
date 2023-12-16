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
    public class HealthStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HealthStatusController(ApplicationDbContext context)
        {
            _context = context;
        }
        
    [HttpGet("{id}")]
    public async Task<ActionResult<HealthStatus>> GetHealthStatus(int id)
    {
        var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.Id == id);

        if (healthStatus == null)
        {
            return NotFound();
        }

        return healthStatus;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateHealthStatus(int id, HealthStatus healthStatusUpdate)
    {
        var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.Id == id);

        if (healthStatus == null)
        {
            return NotFound();
        }
            healthStatus.Weight = healthStatusUpdate.Weight;
            healthStatus.CheckupDate = healthStatusUpdate.CheckupDate;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
}