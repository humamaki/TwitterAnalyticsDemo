using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterAnalytics.Models
{
    public class TweetSearch
    {
        public double Long { get; set; }

        public double Lat { get; set; }

        public int Radius { get; set; }

        public string State { get; set; }
    }
}