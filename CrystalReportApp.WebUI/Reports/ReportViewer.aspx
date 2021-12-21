<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="CrystalReportApp.WebUI.Reports.ReportViewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasPrintButton="True"
                                    autodatabind="false"
                                    HasCrystalLogo="False" 
                                    HasRefreshButton="False"                 
                                    HasToggleGroupTreeButton="False" ToolPanelView="None" 
                                    EnableTheming="False" PageZoomFactor="125" />
        </div>
    </form>



</body>
</html>
