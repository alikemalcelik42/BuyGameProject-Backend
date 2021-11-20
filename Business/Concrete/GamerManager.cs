using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class GamerManager : IGamerService
    {
        IGamerDal _gamerDal;

        public GamerManager(IGamerDal gamerDal)
        {
            _gamerDal = gamerDal;
        }

        [CacheRemoveAspect("IGamerService.Get")]
        [ValidationAspect(typeof(GamerValidator))]
        public IResult Add(Gamer gamer)
        {
            _gamerDal.Add(gamer);
            return new SuccessResult(Messages.GamerAdded);
        }

        [CacheRemoveAspect("IGamerService.Get")]
        [ValidationAspect(typeof(GamerValidator))]
        public IResult Delete(Gamer gamer)
        {
            _gamerDal.Delete(gamer);
            return new SuccessResult(Messages.GamerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Gamer>> GetAll()
        {
            return new SuccessDataResult<List<Gamer>>(_gamerDal.GetAll(), Messages.GamersListed);
        }

        public IDataResult<Gamer> GetById(int id)
        {
            return new SuccessDataResult<Gamer>(_gamerDal.Get(g => g.Id == id), Messages.GamersListed);
        }

        public IDataResult<List<GamerDetailDto>> GetGamerDetails()
        {
            return new SuccessDataResult<List<GamerDetailDto>>(_gamerDal.GetGamerDetails(), Messages.GamersListed);
        }

        [CacheRemoveAspect("IGamerService.Get")]
        [ValidationAspect(typeof(GamerValidator))]
        public IResult Update(Gamer gamer)
        {
            _gamerDal.Update(gamer);
            return new SuccessResult(Messages.GamerUpdated);
        }
    }
}
