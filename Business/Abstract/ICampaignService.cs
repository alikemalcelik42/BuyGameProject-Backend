using Core.Utilities.Results.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        IDataResult<List<Campaign>> GetAll();
        IDataResult<List<Campaign>> GetAllValids();
        IDataResult<Campaign> GetById(int id);
        IResult Add(Campaign campaign);
        IResult Update(Campaign campaign);
        IResult Delete(Campaign campaign);
    }
}
