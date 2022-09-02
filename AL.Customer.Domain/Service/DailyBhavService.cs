using AL.Customer.Data.DbModels;
using AL.Customer.Data.Interface;
using AL.Customer.Domain.Interface;
using AL.Customer.Effigy.Model;
using AL.Customer.Effigy.Model.Grid;
using AL.Customer.Effigy.Model.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Service
{
    public class DailyBhavService : IDailyBhavService
    {
        /// <summary>
        /// Defines the User Repository.
        /// </summary>
        private readonly IDailyBhavRepository dailyBhavRepository;

        private readonly IMapper mapper;

        public DailyBhavService(IDailyBhavRepository _dailyBhavRepository, IMapper _mapper)
        {
            this.dailyBhavRepository = _dailyBhavRepository;
            this.mapper = _mapper;
        }
        public Task<PaginatedGridResultModel> GetDailyBhavService(GridDetailsModel detailsModel)
        {
            string whereCondition = string.Empty;
            string sortColumn = string.Empty;
            PaginatedGridResultModel model = new PaginatedGridResultModel();
            if (detailsModel != null)
            {
                //sortColumn = GetSortColumnName(detailsModel.GridSortColumnNames);
                //whereCondition += this.GetQuickSearchCondition(detailsModel.QuickSearchTerm);
                model = this.dailyBhavRepository.GetDailyBhavRepository(whereCondition, detailsModel.Page, detailsModel.PageRecordCount, sortColumn);
            }
            return Task.FromResult(model);
        }

        public IEnumerable<DailyBhavModel> getAllBhav()
        {
            return this.dailyBhavRepository.getAllBhav();
        }

        private static string GetSortColumnName(List<GridSortColumnModel> gridSortColumnNames)
        {
            string sortColumnQuery = string.Empty;
            List<string> sortColumnDetails = new List<string>();

            foreach (GridSortColumnModel sortDetails in gridSortColumnNames)
            {
                sortColumnQuery = sortDetails.SortColumnNames;
                GridOrderingEnum orderBy = (GridOrderingEnum)Enum.Parse(typeof(GridOrderingEnum), sortDetails.SortOrder.ToUpperInvariant());
                if (orderBy == GridOrderingEnum.DESC)
                {
                    sortColumnQuery += " DESC";
                }
                else
                {
                    sortColumnQuery += " ASC";
                }

                sortColumnDetails.Add(sortColumnQuery);
            }

            sortColumnQuery = string.Join(",", sortColumnDetails);
            return sortColumnQuery;
        }


        /// <summary>
        /// Method to get quick search condition.
        /// </summary>
        /// <param name="quickSearchTerm">Quick search text to be searched.</param>
        /// <returns>Query string with quick search term to search.</returns>
        private string GetQuickSearchCondition(string quickSearchTerm)
        {
            string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(quickSearchTerm))
            {
                whereCondition = string.Format(CultureInfo.InvariantCulture, "(A.Identifier like '%{0}%' OR B.Name like '%{0}%' OR S.StationName like '%{0}%' OR BA.Identifier like '%{0}%'  OR A.IsAutoAward like '%{0}%')", quickSearchTerm);
            }

            whereCondition = string.IsNullOrWhiteSpace(whereCondition) ? string.Empty : " AND " + whereCondition;
            return whereCondition;
        }
    }
}
