using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Web.Script.Serialization;

namespace Project.Common.WebUtil.Convert
{
    public class GenericSerialize
    {
        /// <summary>
        /// XmlType : only XmlDocument or XDocument class use
        /// JSon : 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pSerializeEnumType"></param>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public object ConvertGenericSerialization<T>(ConvertTypeEnum.SerializeEnum pSerializeEnumType, object pObj) where T : new()
        {
            object obj = new T();

            switch (pSerializeEnumType)
            {
                case ConvertTypeEnum.SerializeEnum.Xml:
                    {
                        obj = ConvertXmlSerialization<T>(pObj);
                        break;
                    }
                case ConvertTypeEnum.SerializeEnum.Json:
                    {
                        obj = ConvertXmlSerialization<T>(pObj);
                        break;
                    }
                case ConvertTypeEnum.SerializeEnum.File:
                    {
                        break;
                    }
            }

            return obj;
        }

        /// <summary>
        /// object -> Xml Form or string(XML) etc ....
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObj"></param>
        /// <returns></returns>
        private T ConvertXmlSerialization<T>(object pObj)
        {
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                XmlDocument Xmldoc = new XmlDocument();
                XDocument Xdoc = new XDocument();

                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, pObj);

                    if (ms.Length > 0 && ms.CanRead)
                    {
                        Xmldoc.Load(ms);
                        Xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);

                        Xdoc = XDocument.Load(ms);
                    }
                }

                if (typeof(T) == typeof(XmlDocument))
                    return (T)System.Convert.ChangeType(Xmldoc, typeof(T));
                else if (typeof(T) == typeof(XDocument))
                    return (T)System.Convert.ChangeType(Xdoc, typeof(T));
                else
                    throw new Exception("컨버팅이 불가능한 제네릭 타입을 입력하셨습니다.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// object -> Json string Form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObj"></param>
        /// <returns></returns>
        private T ConvertJsonSerialization<T>(object pObj)
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(pObj);

                if (typeof(T) == typeof(string))
                    return (T)System.Convert.ChangeType(json, typeof(T));
                else
                    throw new Exception("컨버팅이 불가능한 제네릭 타입을 입력하셨습니다.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
