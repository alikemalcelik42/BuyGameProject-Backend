using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IGamerService
    {
        IDataResult<List<Gamer>> GetAll();
        IDataResult<List<GamerDetailDto>> GetGamerDetails();
        IDataResult<Gamer> GetById(int id);
        IResult Add(Gamer gamer);
        IResult Update(Gamer gamer);
        IResult Delete(Gamer gamer);
    }
}
