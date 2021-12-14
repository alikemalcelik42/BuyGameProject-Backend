using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Secure;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;

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
        // [SecuredOperation("admin,game.add")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult(Messages.GameAdded);
        }

        [CacheRemoveAspect("IGameService.Get")]
        [ValidationAspect(typeof(GameValidator))]
        // [SecuredOperation("admin,game.delete")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Game game)
        {
            _gameDal.Delete(game);
            return new SuccessResult(Messages.GameDeleted);
        }

        [PerformanceAspect(3)]
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
        // [SecuredOperation("admin,game.update")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult(Messages.GameUpdated);
        }
    }
}
