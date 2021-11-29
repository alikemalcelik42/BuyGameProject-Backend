using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGamerDal : IEntityRepository<Gamer>
    {
        List<GamerDetailDto> GetGamerDetails();
    }
}
