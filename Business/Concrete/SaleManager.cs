using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;
        ICampaignService _campaignService;
        IGameService _gameService;

        public SaleManager(ISaleDal saleDal, ICampaignService campaignService, IGameService gameService)
        {
            _saleDal = saleDal;
            _campaignService = campaignService;
            _gameService = gameService;
        }

        [CacheRemoveAspect("ISaleService.Get")]
        [SecuredOperation("admin,sale.add")]
        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public IResult Add(Sale sale)
        {
            sale.Amount = _gameService.GetById(sale.GameId).Data.UnitPrice;
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }

        [CacheRemoveAspect("ISaleService.Get")]
        [SecuredOperation("admin,sale.add")]
        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public IResult AddWithCampaigns(Sale sale)
        {
            var result = _campaignService.GetAllValids();
            sale.Amount = _gameService.GetById(sale.GameId).Data.UnitPrice;

            if (result.Success)
            {
                foreach (var campaign in result.Data)
                {
                    sale.Amount -= sale.Amount * (decimal)campaign.DiscountPercentage / (decimal)100;
                }
            }
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }

        [CacheRemoveAspect("ISaleService.Get")]
        [SecuredOperation("admin,sale.delete")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Sale sale)
        {
            _saleDal.Delete(sale);
            return new SuccessResult(Messages.SaleDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll(), Messages.SalesListed);
        }

        public IDataResult<List<Sale>> GetAllByGameId(int gameId)
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll(s => s.GameId == gameId), Messages.SalesListed);
        }

        public IDataResult<List<Sale>> GetAllByGamerId(int gamerId)
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll(s => s.GamerId == gamerId), Messages.SalesListed);
        }

        public IDataResult<Sale> GetById(int id)
        {
            return new SuccessDataResult<Sale>(_saleDal.Get(s => s.Id == id), Messages.SalesListed);
        }

        [PerformanceAspect(3)]
        [CacheAspect]
        public IDataResult<List<SaleDetailDTO>> GetSaleDetails()
        {
            return new SuccessDataResult<List<SaleDetailDTO>>(_saleDal.GetSaleDetails(), Messages.SalesListed);
        }

        [CacheRemoveAspect("ISaleService.Get")]
        [ValidationAspect(typeof(GameValidator))]
        [SecuredOperation("admin,sale.update")]
        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public IResult Update(Sale sale)
        {
            _saleDal.Update(sale);
            return new SuccessResult(Messages.SaleUpdated);
        }
    }
}
