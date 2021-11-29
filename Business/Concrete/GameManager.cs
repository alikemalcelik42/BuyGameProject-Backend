using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Secure;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        IGameDal _gameDal;

        public GameManager(IGameDal gameDal)
        {
            _gameDal = gameDal;
        }

        [CacheRemoveAspect("IGameService.Get")]
        [ValidationAspect(typeof(GameValidator))]
        [SecuredOperation("admin,game.add")]
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult(Messages.GameAdded);
        }

        [CacheRemoveAspect("IGameService.Get")]
        [ValidationAspect(typeof(GameValidator))]
        [SecuredOperation("admin,game.delete")]
        public IResult Delete(Game game)
        {
            _gameDal.Delete(game);
            return new SuccessResult(Messages.GameDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Game>> GetAll()
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll(), Messages.GamesListed);
        }

        public IDataResult<List<Game>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll(g => g.UnitPrice >= min && g.UnitPrice <= max),
                Messages.GamesListed);
        }

        public IDataResult<Game> GetById(int id)
        {
            return new SuccessDataResult<Game>(_gameDal.Get(g => g.Id == id), Messages.GamesListed);
        }

        [CacheRemoveAspect("IGameService.Get")]
        [ValidationAspect(typeof(GameValidator))]
        [SecuredOperation("admin,game.update")]
        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult(Messages.GameUpdated);
        }
    }
}
