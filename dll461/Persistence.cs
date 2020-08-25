using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll461
{
    public static class Persistence
    {
        private static Market ds = new Market();
        public static int SaveMetaData(string information, string symbol, DateTime lastRefreshed,
            string interval, string outputSize, string timeZone)
        {
            var row = ds.Metadata.AddMetadataRow(information, symbol, lastRefreshed,
                interval, outputSize, timeZone);
            return row.Id;

        }
        public static void SaveTimeSeries(int metaDataId, DateTime sampleTime,
            decimal open,
            decimal high,
            decimal low,
            decimal close,
            int volume
            )
        {
            var it = ds.Metadata.DefaultView.FindRows(metaDataId).FirstOrDefault();
            //DefaultView.RowFilter = "Id = " + metaDataId;
            ds.Timeseries.AddTimeseriesRow((Market.MetadataRow)it.Row, sampleTime, open, high, low, close, volume);

        }
    }
}
