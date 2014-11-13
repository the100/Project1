using Project.Common.Server.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_DataBase_Test_DBTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DbTestProject.DbConnectionTest DbConTest = new DbTestProject.DbConnectionTest();

        DbConTest.DbTest();
    }
}