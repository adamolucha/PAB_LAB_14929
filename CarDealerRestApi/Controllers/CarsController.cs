using CarDealershipRestApi.Data;
using CarDealershipRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class Controller(CarDealershipContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await context.Cars.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            context.Cars.Add(car);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCars), new { id = car.Id }, car);
        }
    }

}
