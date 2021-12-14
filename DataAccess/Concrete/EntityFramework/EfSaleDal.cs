using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSaleDal : EfEntityRepositoryBase<Sale, BuyGameContext>, ISaleDal
    {
        public List<SaleDetailDTO> GetSaleDetails()
        {
            using (BuyGameContext context = new BuyGameContext())
            {
                var saleDetails = from s in context.Sales
                                  join gamer in context.Gamers
                                  on s.Id equals gamer.Id
                                  join u in context.Users
                                  on gamer.UserId equals u.Id
                                  join game in context.Games
                                  on s.GameId equals game.Id
                                  select new SaleDetailDTO()
                                  {
                                      GamerNationalNumber = gamer.NationalNumber,
                                      GamerFirstName = u.FirstName,
                                      GamerLastName = u.LastName,
                                      GamerEmail = u.Email,
                                      GamerStatus = u.Status,
                                      GameName = game.Name,
                                      GameUnitPrice = game.UnitPrice,
                                      SaleDate = s.SaleDate
                                  };

                return saleDetails.ToList();
            }
        }
    }
}