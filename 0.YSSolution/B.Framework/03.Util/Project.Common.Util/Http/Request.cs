using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.WebUtil.Http
{
    public static class Req
    {
        /// <summary>
        /// Request Value 값을 String 형 으로 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 빈문자로 반환한다.</param>
        /// <returns></returns>
        public static string GetString(string pRequestName, string pDefaultValue = "")
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                    return page.Request[pRequestName].ToString();
            }
            catch
            {
                return pDefaultValue;
            }
        }

        /// <summary>
        /// Request Value 값을 Int 형 으로 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 0으로 반환한다.</param>
        /// <returns></returns>
        public static int GetInteager(string pRequestName, int pDefaultValue = 0)
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                    return System.Convert.ToInt32(page.Request[pRequestName]);
            }
            catch
            {
                return pDefaultValue;
            }
        }

        /// <summary>
        /// Request Value 값을 Long 형 으로 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 0으로 반환한다.</param>
        /// <returns></returns>
        public static long GetLong(string pRequestName, int pDefaultValue = 0)
        {   
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                    return System.Convert.ToInt64(page.Request[pRequestName]);
            }
            catch
            {
                return pDefaultValue;
            }
        }


        /// <summary>
        /// Request Value 값을 Decimal 형 으로 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 0으로 반환한다.</param>
        /// <returns></returns>
        public static decimal GetDecimal(string pRequestName, decimal pDefaultValue = 0)
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                    return System.Convert.ToDecimal(page.Request[pRequestName]);
            }
            catch
            {
                return pDefaultValue;
            }
        }

        /// <summary>
        /// Request Value 값을 Float 형 으로 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 0으로 반환한다.</param>
        /// <returns></returns>
        public static float GetFloat(string pRequestName, float pDefaultValue = 0)
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                    return System.Convert.ToSingle(page.Request[pRequestName]);
            }
            catch
            {
                return pDefaultValue;
            }
        }

        /// <summary>
        /// Request Value 값을 Double 형 으로 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 0으로 반환한다.</param>
        /// <returns></returns>
        public static double GetDouble(string pRequestName, double pDefaultValue = 0)
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                    return System.Convert.ToDouble(page.Request[pRequestName]);
            }
            catch
            {
                return pDefaultValue;
            }
        }


        /// <summary>
        /// Request Value 값을 Base64Encode 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 빈문자로 반환한다.</param>
        /// <returns></returns>
        public static string GetBase64Encode(string pRequestName, string pDefaultValue = "")
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                {
                    byte[] arrByte = System.Text.Encoding.UTF8.GetBytes(page.Request[pRequestName].ToString());

                    return System.Convert.ToBase64String(arrByte, Base64FormattingOptions.None);
                }
            }
            catch
            {
                return pDefaultValue;
            }
        }


        /// <summary>
        /// Request Value 값을 Base64Decode 반환한다.
        /// </summary>
        /// <param name="pRequestName">Request Name</param>
        /// <param name="pDefaultValue">반환될 기본정보 미 입력시 빈문자로 반환한다.</param>
        /// <returns></returns>
        public static string GetBase64Decode(string pRequestName, string pDefaultValue = "")
        {
            try
            {
                System.Web.UI.Page page = new System.Web.UI.Page();
                if (page.Request[pRequestName] == null)
                    return pDefaultValue;
                else
                {
                    byte[] arrByte = System.Convert.FromBase64String(page.Request[pRequestName]);

                    return System.Text.Encoding.UTF8.GetString(arrByte);
                }
            }
            catch
            {
                return pDefaultValue;
            }
        }

    }
}
