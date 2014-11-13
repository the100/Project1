using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.WebUtil.SendMail
{
    public class MailEntity
    {
        private SendMailServerType _ServerType;
        private SendMailType _MailType;
        private string _URL;
        private string _From;
        private string _DisplayName;
        private Encoding _DisplayNameEncoding;
        private string _To;
        private string _Cc;
        private string _Subject;
        private Encoding _SubjectEncoding;
        private string _Body;
        private Encoding _BodyEncoding;
        private string _AttachFileName;
        private bool _SSL;

        /// <summary>보낼 서버 타입</summary>
        public SendMailServerType ServerType
        {
            get { return this._ServerType; }
            set { this._ServerType = value; }
        }

        /// <summary>보낼 메일 타입</summary>
        public SendMailType MailType
        {
            get { return this._MailType; }
            set { this._MailType = value; }
        }

        /// <summary>해당 URL 의 HTML 을 긁어올때 사용</summary>
        public string URL
        {
            get { return this._URL; }
            set { this._URL = value; }
        }

        /// <summary>보내는사람</summary>
        public string From
        {
            get { return this._From; }
            set { this._From = value; }
        }

        /// <summary>보여질 이름(NameCard...)</summary>
        public string DisplayName
        {
            get { return this._DisplayName; }
            set { this._DisplayName = value; }
        }

        /// <summary>보여질 이름 인코딩타입</summary>
        public Encoding DisplayNameEncoding
        {
            get { return this._DisplayNameEncoding; }
            set { this._DisplayNameEncoding = value; }
        }

        /// <summary>받는사람(, 구분자를 사용해서 여러명에서 보낸다.)</summary>
        public string To
        {
            get { return this._To; }
            set { this._To = value; }
        }

        /// <summary>받는사람(, 구분자를 사용해서 여러명에서 보낸다.)</summary>
        public string CC
        {
            get { return this._Cc; }
            set { this._Cc = value; }
        }

        /// <summary>제목</summary>
        public string Subject
        {
            get { return this._Subject; }
            set { this._Subject = value; }
        }

        /// <summary>제목인코딩타입</summary>
        public Encoding SubjectEncoding
        {
            get { return this._SubjectEncoding; }
            set { this._SubjectEncoding = value; }
        }

        /// <summary>내용</summary>
        public string Body
        {
            get { return this._Body; }
            set { this._Body = value; }
        }

        /// <summary>내용인코딩타입</summary>
        public Encoding BodyEncoding
        {
            get { return this._BodyEncoding; }
            set { this._BodyEncoding = value; }
        }

        /// <summary>첨부파일명(, 구분자를 사용해서 여러파일을 보낸다.)</summary>
        public string AttachFileName
        {
            get { return this._AttachFileName; }
            set { this._AttachFileName = value; }
        }

        /// <summary>SSL 연결 Flag(SendMailServerType Default 사용시 필요없음. Default 외 필수사항)</summary>
        public bool isSSL
        {
            get { return this._SSL; }
            set { this._SSL = value; }
        }
    }
}
