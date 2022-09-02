using AL.Customer.Effigy.Model.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Effigy.Model
{
    public class DailyBhavModel :BaseGridRecord
    {
        public int Id { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public string Symbol { get; set; }
        public string Series { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Close { get; set; }
        public decimal? Last { get; set; }
        public decimal? Prevclose { get; set; }
        public int? Tottrdqty { get; set; }
        public decimal? Tottrdval { get; set; }
        public string Timestamp { get; set; }
        public int? Totaltrades { get; set; }
        public string Isin { get; set; }
    }
}
