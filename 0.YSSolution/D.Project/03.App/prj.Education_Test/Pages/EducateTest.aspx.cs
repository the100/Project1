using Project.Common.WebUtil.SendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_EducateTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Project.Common.WebUtil.Http.HTML html = new Project.Common.WebUtil.Http.HTML();
        
        Project.Common.WebUtil.SendMail.MailEntity mail = new Project.Common.WebUtil.SendMail.MailEntity();

        mail.From = "jounh135@gamil.com";
        mail.To = "tyrs1982@naver.com";
        mail.Subject = "테스트 이메일";
        mail.DisplayName = "김영신";
        mail.Body = html.GetHtmlInfo("http://www.naver.com");
        mail.MailType = Project.Common.WebUtil.SendMail.SendMailType.Text;
        mail.ServerType = Project.Common.WebUtil.SendMail.SendMailServerType.Default;
        
        SendMail send = new SendMail();
        send.Send(mail);
    }
}