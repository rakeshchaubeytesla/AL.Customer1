using AL.Customer.Data.DbModels;
using AL.Customer.Effigy.Model;
using AL.Customer.Effigy.Model.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Interface
{
    public interface IDailyBhavService
    {
        Task<PaginatedGridResultModel> GetDailyBhavService(GridDetailsModel detailsModel);

        IEnumerable<DailyBhavModel> getAllBhav();
    }
}
