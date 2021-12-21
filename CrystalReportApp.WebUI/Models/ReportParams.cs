using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportApp.WebUI.Models
{
    public class ReportParams<T>
    {
        public string ReportFileName { get; set; }
        public string ReportTitle { get; set; }
        public List<T> DataSource { get; set; }
        public bool IsPassParam { get; set; }
    }
}