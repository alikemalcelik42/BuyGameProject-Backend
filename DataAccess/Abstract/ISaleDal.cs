using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface ISaleDal : IEntityRepository<Sale>
    {
        List<SaleDetailDTO> GetSaleDetails();
    }
}
