using Carental.Application.Contracts.Identity;
using Carental.Application.Contracts.Persistence.ComplexQuery;
using Carental.Application.DTOs.Persistence.Rental;
using Carental.Domain.Entities;
using Carental.Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Infrastructure.Persistence.Services
{
    internal class GetRentalsService : IGetRentals
    {
        private readonly AppDBContext _dbContext;
        private readonly IUserManager _userManager;

        public GetRentalsService(AppDBContext dbContext, IUserManager userManager)
        {
            _dbContext = dbContext;
        }

        public async IAsyncEnumerable<CarRentalsResponse> Execute()
        {
            var query = _dbContext.CarRentals
                .Include(x => x.CarInventory)
                .ThenInclude(x => x.Car)
                .Include(x => x.Customer)
                .Include(x => x.CarDamage)
                .Select(c => new
                {
                    CarId = c.CarInventoryId,
                    CarMake = c.CarInventory.Car.Make,
                    CarModel = c.CarInventory.Car.Model,
                    CarYear = c.CarInventory.Car.Year,
                    RentalRate = c.CarInventory.RentalRate,
                    RequestDate = c.RequestDate,
                    ApprovalStatus = c.ApprovalStatus,
                    IsCancelled = c.IsCancelled,
                    IsReturned = c.IsReturned,
                    CarDamageId = c.CarDamage.Id,
                    CustomerId = c.CustomerId,
                });
            await foreach(var v in query.AsAsyncEnumerable())
            {
                var r = v.Adapt<CarRentalsResponse>();
                yield return r;
            }                
        }
    }
}
