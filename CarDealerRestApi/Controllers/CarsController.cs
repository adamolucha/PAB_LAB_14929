using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealershipRestApi.Models;

namespace CarDealershipRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly IDictionary<int, Car> _cars = new Dictionary<int, Car>();
        private static int _nextCarId = 1;

        // GET: api/Cars
        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_cars.Values.ToList());
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            if (!_cars.ContainsKey(id))
            {
                return NotFound();
            }

            return Ok(_cars[id]);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public IActionResult PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            if (!_cars.ContainsKey(id))
            {
                return NotFound();
            }

            _cars[id] = car;
            return NoContent();
        }

        // POST: api/Cars
        [HttpPost]
        public IActionResult PostCar(Car car)
        {
            car.Id = _nextCarId++;
            _cars[car.Id] = car;
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            if (!_cars.ContainsKey(id))
            {
                return NotFound();
            }

            _cars.Remove(id);
            return NoContent();
        }
    }
}
