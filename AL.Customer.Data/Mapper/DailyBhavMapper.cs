using AL.Customer.Data.DbModels;
using AL.Customer.Effigy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Data.Mapper
{
    public static class DailyBhavMapper
    {
        public static List<DailyBhavModel> MapBhavList(List<DailyBhav> dailyBhavs)
        {
            List<DailyBhavModel> dailyBhavListModels = new List<DailyBhavModel>();
            if(dailyBhavs != null)
            {
                foreach (var item in dailyBhavs)
                {
                    DailyBhavModel dailyBhavModel = new DailyBhavModel();   
                    dailyBhavModel.Id = item.Id;
                    dailyBhavModel.GeneratedDate = item.GeneratedDate;
                    dailyBhavModel.Symbol = item.Symbol;
                    dailyBhavModel.Series = item.Series;
                    dailyBhavModel.Open = item.Open;
                    dailyBhavModel.High = item.High;
                    dailyBhavModel.Low = item.Low;
                    dailyBhavModel.Close = item.Close;
                    dailyBhavModel.Last = item.Last;
                    dailyBhavModel.Prevclose = item.Prevclose;
                    dailyBhavModel.Tottrdqty = item.Tottrdqty;
                    dailyBhavModel.Tottrdval = item.Tottrdval;
                    dailyBhavModel.Timestamp = item.Timestamp;
                    dailyBhavModel.Totaltrades = item.Totaltrades;
                    dailyBhavModel.Isin = item.Isin;
                    dailyBhavListModels.Add(dailyBhavModel);
                }
            }

            return dailyBhavListModels;
        }
    }
}
