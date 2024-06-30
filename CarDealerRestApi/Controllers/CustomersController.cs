using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealershipRestApi.Models;

namespace CarDealershipRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly IDictionary<int, Customer> _customers = new Dictionary<int, Customer>();
        private static int _nextCustomerId = 1;

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_customers.Values.ToList());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            if (!_customers.ContainsKey(id))
            {
                return NotFound();
            }

            return Ok(_customers[id]);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            if (!_customers.ContainsKey(id))
            {
                return NotFound();
            }

            _customers[id] = customer;
            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            customer.Id = _nextCustomerId++;
            _customers[customer.Id] = customer;
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_customers.ContainsKey(id))
            {
                return NotFound();
            }

            _customers.Remove(id);
            return NoContent();
        }
    }
}
