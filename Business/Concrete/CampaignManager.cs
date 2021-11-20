﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        ICampaignDal _campaignDal;

        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }

        [ValidationAspect(typeof(CampaignValidator))]
        [CacheRemoveAspect("ICampaignService.Get")]
        public IResult Add(Campaign campaign)
        {
            _campaignDal.Add(campaign);
            return new SuccessResult(Messages.CampaignAdded);
        }

        [ValidationAspect(typeof(CampaignValidator))]
        [CacheRemoveAspect("ICampaignService.Get")]
        public IResult Delete(Campaign campaign)
        {
            _campaignDal.Delete(campaign);
            return new SuccessResult(Messages.CampaignDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Campaign>> GetAll()
        {
            return new SuccessDataResult<List<Campaign>>(_campaignDal.GetAll(), Messages.CampaignsListed);
        }

        public IDataResult<List<Campaign>> GetAllValids()
        {
            return new SuccessDataResult<List<Campaign>>(_campaignDal.GetAll(c => c.FinishDate > DateTime.Now),
                Messages.CampaignsListed);
        }

        public IDataResult<Campaign> GetById(int id)
        {
            return new SuccessDataResult<Campaign>(_campaignDal.Get(g => g.Id == id), Messages.CampaignsListed);
        }

        [ValidationAspect(typeof(CampaignValidator))]
        [CacheRemoveAspect("ICampaignService.Get")]
        public IResult Update(Campaign campaign)
        {
            _campaignDal.Update(campaign);
            return new SuccessResult(Messages.CampaignUpdated);
        }
    }
}
