using Carental.Application.Contracts.Identity;
using Carental.Application.Contracts.Persistence.ComplexQuery;
using Carental.Application.DTOs.Identity;
using Carental.Application.DTOs.Persistence.Rental;
using Carental.Domain.Entities;
using Carental.Domain.Enums;
using Castle.Core.Resource;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            _userManager = userManager;
        }

        public async IAsyncEnumerable<CarRentalsResponseDTO> Execute([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            
            var query = _dbContext.CarRentals
                .Include(x => x.CarInventory)
                .ThenInclude(x => x.Car)
                .Include(x => x.Customer)
                .Include(x => x.CarDamage);
                

            await foreach (var c in query.AsAsyncEnumerable())
            {

                User? user = await _userManager.GetUserByIdAsync(c.CustomerId, cancellationToken: cancellationToken);
                Car car = c.CarInventory.Car;

                yield return new CarRentalsResponseDTO(
                    CarId: c.CarInventoryId,
                    Name: $"{car.Model} {car.Make}, {car.Year}",
                    RentalRate: c.CarInventory.RentalRate,

                    RequestDate: c.RequestDate,
                    ApprovalStatus: c.ApprovalStatus,
                    ApprovedOn: c.ApprovedOn,
                    IsCancelled: c.IsCancelled,
                    IsReturned: c.IsReturned,
                    ReturnOrCancelDateTime: c.ReturnOrCancelDateTime,
                    RentPrice: c.RentPrice,

                    DiscountOfferId: c.DiscountOfferId,
                    VoucherCode: c.DiscountOffer?.Code,
                    DiscountRate: c.DiscountOffer?.DiscountRate ?? 0,

                    CarDamageId: c.CarDamage?.Id,
                    CustomerId: c.CustomerId,
                    UserRole: user?.Role ?? 0
                    );
            }
        }       
    }
}
