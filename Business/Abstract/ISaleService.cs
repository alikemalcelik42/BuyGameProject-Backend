using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ISaleService
    {
        IDataResult<List<Sale>> GetAll();
        IDataResult<List<Sale>> GetAllByGameId(int gameId);
        IDataResult<List<Sale>> GetAllByGamerId(int gamerId);
        IDataResult<List<SaleDetailDTO>> GetSaleDetails();
        IDataResult<Sale> GetById(int id);
        IResult Add(Sale sale);
        IResult AddWithCampaigns(Sale sale);
        IResult Update(Sale sale);
        IResult Delete(Sale sale);
    }
}
