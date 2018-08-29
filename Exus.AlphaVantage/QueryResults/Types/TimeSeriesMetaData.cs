﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.QueryResults.Types
{
    [DataContract]
    public class TimeSeriesMetaData
    {
        [DataMember(Name = "1. Information")]
        public string Information { get; set; }
        [DataMember(Name = "2. Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "3. Last Refreshed")]
        public DateTime LastRefreshed { get; set; }
        [DataMember(Name = "4. Output Size")]
        public string OutputSize { get; set; }
        [DataMember(Name = "5. Time Zone")]
        public string TimeZone { get; set; }
    }
}