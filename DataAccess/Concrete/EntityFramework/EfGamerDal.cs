using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGamerDal : EfEntityRepositoryBase<Gamer, BuyGameContext>, IGamerDal
    {
        public List<GamerDetailDto> GetGamerDetails()
        {
            using(BuyGameContext context = new BuyGameContext())
            {
                var gamerDetails = from g in context.Gamers
                                  join u in context.Users
                                  on g.UserId equals u.Id
                                  select new GamerDetailDto()
                                  {
                                      NationalNumber = g.NationalNumber,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      Email = u.Email,
                                      Status = u.Status
                                  };
                return gamerDetails.ToList();
            }   
        }
    }
}
