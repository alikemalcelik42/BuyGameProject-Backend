using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface IGamerDal : IEntityRepository<Gamer>
    {
        List<GamerDetailDto> GetGamerDetails();
    }
}
