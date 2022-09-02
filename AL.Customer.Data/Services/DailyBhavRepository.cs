using AL.Customer.Data.DbModels;
using AL.Customer.Data.Interface;
using AL.Customer.Data.Mapper;
using AL.Customer.Effigy.Model;
using AL.Customer.Effigy.Model.Grid;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AL.Customer.Data.Services
{
    public class DailyBhavRepository : BaseRepository<DailyBhav>, IDailyBhavRepository
    {
        private readonly FirstMarketContext context;

        public DailyBhavRepository(FirstMarketContext context) : base(context)
        {
            this.context = context;
        }
        public PaginatedGridResultModel GetDailyBhavRepository(string whereCondition, int page, int pageRecordCount, string sortColumn)
        {
            int dailyBhavTotalCount = 0;
            List<DailyBhavModel> dailyBhavIndexModels = new List<DailyBhavModel>();
            PaginatedGridResultModel paginatedGridResult = new PaginatedGridResultModel();

            var whereConditionParam = new SqlParameter("@whereCondition", whereCondition);
            var pageCountParam = new SqlParameter("@Page", page.ToString(CultureInfo.InvariantCulture));
            var countParam = new SqlParameter("@Count", pageRecordCount.ToString(CultureInfo.InvariantCulture));
            var orderByColumnParam = new SqlParameter("@orderByColumn", sortColumn);
            Dictionary<string, string> spParams = new Dictionary<string, string>();
            spParams.Add("@whereCondition", whereCondition);
            spParams.Add("@page", page.ToString(CultureInfo.InvariantCulture));
            spParams.Add("@count", pageRecordCount.ToString(CultureInfo.InvariantCulture));
            spParams.Add("@orderByColumn", sortColumn);
            var dailyBhavs = context
                          .DailyBhavs
                          .FromSqlRaw("exec GetDailyBhav @whereCondition,@page,@count,@orderByColumn",
                              new object[] { whereConditionParam, pageCountParam, countParam, orderByColumnParam })
                          .ToList();
            //dailyBhavTotalCount = (dailyBhavs == null) ? 0 : dailyBhavs[0].TotalCount.Value;
            dailyBhavIndexModels = DailyBhavMapper.MapBhavList(dailyBhavs);
            paginatedGridResult.PaginatedInstances.AddRange(dailyBhavIndexModels);
            paginatedGridResult.TotalCount = dailyBhavTotalCount;
            return paginatedGridResult;

        }
        
        public IEnumerable<DailyBhavModel> getAllBhav()
        {
            var dbBhav =  db.DailyBhavs.ToList();
            return DailyBhavMapper.MapBhavList(dbBhav);
        }


    }
}
