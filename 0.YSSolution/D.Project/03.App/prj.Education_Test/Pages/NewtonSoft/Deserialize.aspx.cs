using Newtonsoft.Json;
using Prj.Accommodation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_NewtonSoft_Deserialize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = @"{
                            'Article': {
                                'areaNo': 1000181,
                                'address1': '서울시 강북구 미아동',
                                'address2': '4-90',
                                'address3': '102호',
                                'category1': '재개발',
                                'category1': '단독/다가구',
                                'spc1': 252.5,
                                'spc2': 134,
                                'spc3': 134,
                                'spc4': 215,
                                'floor1': 3,
                                'floor2': 5
                            }
                        }";

        Class1test m = JsonConvert.DeserializeObject<Class1test>(json);

        ltrData.Text = m.Article.Address1;
    }
}