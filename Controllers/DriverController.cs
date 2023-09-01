using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fromulaApi.DataBase;
using fromulaApi.Model;
using fromulaApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fromulaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class DriverController : ControllerBase
    {
        private readonly IUnitOfWork _unitOFWork;

        public DriverController(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }

        [HttpGet("getDrivers")]
        public async Task<ActionResult<List<Driver>>> GetDrivers()
        {
            try
            {
                var drivers = await _unitOFWork.Drivers.All();

                if (drivers == null)
                {
                    return NotFound(); // 404 Not Found if no drivers were found.
                }

                return Ok(drivers); // 200 OK with the list of drivers.
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way that's appropriate for your application.
                return StatusCode(500, "An error occurred."); // 500 Internal Server Error.
            }
        }


        [HttpGet("/driver{id:int}")]
        public async Task<ActionResult> GetDriver(int id)
        {
            var Driver = await _unitOFWork.Drivers.GetByID(id);
            if (Driver is not null)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("/addDriver")]
        public async Task<ActionResult> AddDriver([FromBody] Driver newDriver)
        {
            await _unitOFWork.Drivers.Add(newDriver);
            await _unitOFWork.CompleteAsync();
            return Ok("Added");
        }
        [HttpDelete("/deleteDriver")]
        public async Task<ActionResult> DeleteDriver(int id)
        {
            var existedDriver = await _unitOFWork.Drivers.GetByID(id);
            await _unitOFWork.Drivers.Delete(existedDriver);
            await _unitOFWork.CompleteAsync();
            return Ok();
        }
        [HttpPatch("/updateDriver")]
        public async Task<ActionResult> UpdateDriver([FromBody] Driver updateDriver)
        {
            var existedDriver = await _unitOFWork.Drivers.GetByID(updateDriver.Id);
            if (existedDriver is null)
            {
                return NotFound();
            }
            await _unitOFWork.Drivers.Update(updateDriver);
            await _unitOFWork.CompleteAsync();
            return Ok();
        }
    }
}