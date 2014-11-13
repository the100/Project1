using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace Project.Common.WebUtil.SendMail
{
    public class SendMail
    {
        /// <summary>
        /// 메인보내기
        /// </summary>
        /// <param name="pEntity">메일전용 Model</param>
        /// <returns></returns>
        public object Send(MailEntity pEntity)
        {
            try
            {
                string strHost = string.Empty;
                int port = 0;
                string GmailID = System.Web.Configuration.WebConfigurationManager.AppSettings["GmailID"].ToString();
                string GmailPassWord = System.Web.Configuration.WebConfigurationManager.AppSettings["GmailPW"].ToString();

                SmtpClient smtp = null;//smtp 셋팅

                if (pEntity.ServerType == SendMailServerType.Default)
                {
                    strHost = "smtp.gmail.com";//Mail 서버가 없다면 쥐메일 SMTP 주소를 사용한다.
                    port = 587;//Mail 서버가 없다면 쥐메일 PORT를 사용한다.
                }
                else
                {
                    strHost = System.Web.Configuration.WebConfigurationManager.AppSettings["MailHost"].ToString();//Mail Server Host Info
                    port = System.Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["MailPort"]);//Mail Server Port Info
                }

                if (port != 0)
                    smtp = new SmtpClient(strHost, port);
                else
                    smtp = new SmtpClient(strHost);

                if (pEntity.ServerType == SendMailServerType.Default)//Gmail SMTP 사용을 위한 셋팅
                {
                    smtp.Credentials = new System.Net.NetworkCredential(GmailID, GmailPassWord);//Gmail 인증을 위한 아이디 , 패스워드 정보
                    smtp.EnableSsl = true;//gmail 은 true로 설정해야 된다고함
                }
                else
                {
                    smtp.EnableSsl = pEntity.isSSL;//연결 암호화 설정여부
                }

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(pEntity.From, pEntity.DisplayName, pEntity.DisplayNameEncoding == null ? Encoding.UTF8 : pEntity.DisplayNameEncoding);//보내는사람

                if (!string.IsNullOrEmpty(pEntity.To))
                {
                    string[] splitTo = pEntity.To.Split(',');//받는인원 구분하기

                    foreach (string value in splitTo)
                    {
                        mail.To.Add(value);//받을사람
                    }
                }

                if(!string.IsNullOrEmpty(pEntity.CC))
                {
                    string[] splitCc = pEntity.CC.Split(',');//참조인원 구분하기

                    foreach (string value in splitCc)
                    {
                        mail.CC.Add(value);//참조
                    }
                }

                mail.Subject = pEntity.Subject;//제목
                mail.SubjectEncoding = pEntity.SubjectEncoding == null ? Encoding.UTF8 : pEntity.SubjectEncoding;//제목인코딩

                if (pEntity.MailType == SendMailType.URL)//URL Scrap 을 선택했다면
                {
                    Project.Common.WebUtil.Http.HTML html = new Http.HTML();
                    pEntity.Body = html.GetHtmlInfo(pEntity.URL);//HTML 스크랩 해오기

                    if (pEntity.BodyEncoding == null)
                        pEntity.BodyEncoding = Encoding.UTF8;
                }

                mail.Body = pEntity.Body;//보낼내용
                mail.BodyEncoding = pEntity.BodyEncoding == null ? Encoding.UTF8 : pEntity.BodyEncoding; ;//보낼내용 인코딩

                if (!string.IsNullOrEmpty(pEntity.AttachFileName))//첨부파일이 있다면
                {
                    string[] splitFileName = pEntity.AttachFileName.Split(',');//, 구분자로 나눈다.
                    Attachment attachment = null;
                    foreach (string value in splitFileName)//여러개의 파일들을 첨부한다.
                    {
                        attachment = new Attachment(pEntity.AttachFileName);
                        mail.Attachments.Add(attachment);
                    }
                }

                smtp.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
