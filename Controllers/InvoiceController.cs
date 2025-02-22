﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vechicalManagement.Data;
using vechicalManagement.Models;

namespace vechicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("invoice")]
        public async Task<IActionResult> invoice([FromQuery] int vehicleId, [FromBody] ServiceRecord records )
        {
            try
            {
                var workItemUsedInVehicle = _context.WorkItems.
                FirstOrDefault(u => u.VehicleId == vehicleId);
                var vehicle = _context.Vehicles.FirstOrDefault(u => u.Id == vehicleId);
                if (vehicle == null)
                {
                    return NotFound();
                }
                records.vehicleName = vehicle.VehicleName;

                records.Price = workItemUsedInVehicle.Cost;
                records.WorkItemId = workItemUsedInVehicle.Id;


                _context.serviceRecords.Add(records);
                await _context.SaveChangesAsync();


                return Ok();

            }
            catch (Exception ex) { 
            return Ok(ex.ToString());
                    }
            
            
        }
      

        }
}

