using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories.Base;

namespace Infrastructure.Persistence.Repositories
{
    public class DiscountOfferRepository : Repostiory<DiscountOffer>, IDiscountOfferRepository
    {
        public DiscountOfferRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
