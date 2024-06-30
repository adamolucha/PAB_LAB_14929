using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealershipRestApi.Models;

namespace CarDealershipRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static readonly IDictionary<int, Order> _orders = new Dictionary<int, Order>();
        private static int _nextId = 1;

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_orders.Values.ToList());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            if (!_orders.ContainsKey(id))
            {
                return NotFound();
            }

            return Ok(_orders[id]);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            if (!_orders.ContainsKey(id))
            {
                return NotFound();
            }

            _orders[id] = order;
            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrder(Order order)
        {
            order.Id = _nextId++;
            _orders[order.Id] = order;
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (!_orders.ContainsKey(id))
            {
                return NotFound();
            }

            _orders.Remove(id);
            return NoContent();
        }
    }
}
