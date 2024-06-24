using CarDealershipRestApi;
using CarDealershipRestApi.Data;
using CarDealershipRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipTests
{
    public class CarsControllerTests
    {

        private readonly CarsController _controller;
        private readonly CarDealershipContext _context;

        public CarsControllerTests()
        {
            var options = new DbContextOptionsBuilder<CarDealershipContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new CarDealershipContext(options);
            _controller = new CarsController(_context);
        }
        [Fact]
        public async Task GetCars_ReturnsListofCars()

        {
            var result = await _controller.GetCars();   
            Assert.IsType<ActionResult<IEnumerable<Car>>>(result);
        }
    }
}