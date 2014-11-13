<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EducateTest.aspx.cs" Inherits="Pages_EducateTest" %>

<%@ Register Src="~/UserControl/WebUserControl.ascx" TagPrefix="uc1" TagName="WebUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" id="css" href="http://sstatic.naver.net/search/css/2014/api_atcmp_0415.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="test" runat="server" />
        <asp:CheckBox attr="123" ID="test1" runat="server" />
        
        <uc1:WebUserControl runat="server" ID="WebUserControl" />
    </div>
    </form>
</body>
</html>
