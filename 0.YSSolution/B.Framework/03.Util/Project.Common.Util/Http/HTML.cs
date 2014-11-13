using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.WebUtil.Http
{
    public class HTML
    {
        /// <summary>
        /// URL을 이용해서 해당 URL의 HTML 정보를 읽어온다.
        /// </summary>
        /// <param name="pURL"></param>
        /// <returns></returns>
        public string GetHtmlInfo(string pURL)
        {
            WebClient webClient = new WebClient();
            byte[] arrByte = webClient.DownloadData(pURL);

            return Encoding.UTF8.GetString(arrByte);
        }
    }
}
