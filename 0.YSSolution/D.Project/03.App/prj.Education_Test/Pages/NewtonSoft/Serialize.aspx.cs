using Newtonsoft.Json;
using Prj.Accommodation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_NewtonSoft_Serialize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class1test classTest = new Class1test();
        classTest.Article = new Article();
        classTest.Article.Address1 = "Address1";
        classTest.Article.Address2 = "Address2";
        classTest.Article.Address3 = "Address3";
        classTest.Article.Category1 = "Category1";
        classTest.Article.Category2 = "Category2";
        classTest.Article.Spc1 = 1F;
        classTest.Article.Spc2 = 2F;
        classTest.Article.Spc3 = 3F;
        classTest.Article.Spc4 = 4F;
        classTest.Article.Floor1 = 1;
        classTest.Article.Floor2 = 2;

        var result = JsonConvert.SerializeObject(classTest);

        JavaScriptSerializer json = new JavaScriptSerializer();
        var jsonString = json.Serialize(classTest);

        Class1test artDes = json.Deserialize<Class1test>(jsonString);


        ltrData.Text = result;


    }
}