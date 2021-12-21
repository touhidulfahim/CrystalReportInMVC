using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReportApp.WebUI.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        public void LoadReport()
        {
            var reportParam =(dynamic)HttpContext.Current.Session["ReportParam"];
            ReportDocument rd = new ReportDocument();
            var dataSource = reportParam.DataSource;
            string path = Server.MapPath("~") + "Reports/" + reportParam.ReportFileName;
            rd.Load(path);
            rd.SetDataSource(dataSource);
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.RefreshReport();
            string DirectoryPath = Request.PhysicalApplicationPath + "/OpenPDF/BusinessDevelop/";
            string fileName = "/OpenPDF/" + "_PersonData.pdf";
            if (!System.IO.Directory.Exists(DirectoryPath))
            {
                System.IO.Directory.CreateDirectory(DirectoryPath);
            }
            rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath(fileName));
        }
    }
}