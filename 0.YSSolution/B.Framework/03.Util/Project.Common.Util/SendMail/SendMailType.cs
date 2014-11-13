using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.WebUtil.SendMail
{
    public enum SendMailType
    {
        /// <summary>일반적인 Text 형태의 이메일 보낼때 사용</summary>
        Text,
        /// <summary>URL 위치의 HTML 을 긁어와서 이메일 보낼때 사용</summary>
        URL
    }

    public enum SendMailServerType
    {
        /// <summary>기본은 Gmail 정보</summary>
        Default,
        /// <summary>사용자 서버가 있을경우..</summary>
        OwnerServer
    }
}
