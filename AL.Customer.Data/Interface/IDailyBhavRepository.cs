using AL.Customer.Data.DbModels;
using AL.Customer.Effigy.Model;
using AL.Customer.Effigy.Model.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Data.Interface
{
    public interface IDailyBhavRepository
    {
        PaginatedGridResultModel GetDailyBhavRepository(string whereCondition, int page, int pageRecordCount, string sortColumn);

        IEnumerable<DailyBhavModel> getAllBhav();
    }
}
