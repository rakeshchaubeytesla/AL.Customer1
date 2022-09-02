using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Effigy.Model.Grid
{
    public class GridDetailsModel
    {
        public string EntityName { get; set; }
        public string TabName { get; set; }
        public int Page { get; set; }
        public int PageRecordCount { get; set; }
        public string Ordering { get; set; }
        public List<GridSortColumnModel> GridSortColumnNames { get; set; }
        public string QuickSearchTerm { get; set; }
        public string Role { get; set; }
        public List<GridDropDownSearchModel> GridDropDownSelection { get; set; }
        public List<GridDefaultParameterModel> GridDefaultParameters { get; set; }

    }
}
