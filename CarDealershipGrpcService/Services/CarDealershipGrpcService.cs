using CarDealership;
using CarDealershipRestApi.Data;
using CarDealershipRestApi.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipGrpcService.Services
{
    public class CarDealershipService : CarDealershipServiceBase
    {
        private readonly CarDealershipContext _context;

        public CarDealershipService(CarDealershipContext context)
        {
            _context = context;
        }

        public override async Task<CarList> GetCars(Empty request, ServerCallContext context)
        {
            var cars = await _context.Cars.Select(c => new Car
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                Year = c.Year
            }).ToListAsync();

            var carList = new CarList();
            carList.Cars.AddRange(cars);
            return carList;
        }
    }
}