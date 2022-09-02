using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Effigy.Model.Grid
{
    public class PaginatedGridResultModel
    {
        //
        // Summary:
        //     Gets or sets total count of records for selected grid parameters.
        public int TotalCount { get; set; }

        //
        // Summary:
        //     Gets or sets instances to be displayed on grid.
        public List<BaseGridRecord> PaginatedInstances { get; set; }

        //
        // Summary:
        //     Initializes a new instance of the CTS.Rail.Effigy.CCM.Models.Grid.PaginatedGridResultModel
        //     class.
        public PaginatedGridResultModel()
        {
            PaginatedInstances = new List<BaseGridRecord>();
        }
    }
}
