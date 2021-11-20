using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameService
    {
        IDataResult<List<Game>> GetAll();
        IDataResult<List<Game>> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<Game> GetById(int id);
        IResult Add(Game game);
        IResult Update(Game game);
        IResult Delete(Game game);
    }
}
