using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.WebUtil.Convert
{
    public static class EntityForm
    {

        /// <summary>
        /// DataTable -> object Convert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pDt"></param>
        /// <returns></returns>
        public static List<T> DataTableToGeneric<T>(DataTable pDt) where T : class , new() 
        {
            try
            {
                List<T> listObject = new List<T>();
                
                System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();//반환된 정보

                int compareCount = 0;
                foreach (var prop in properties)
                {
                    foreach (DataColumn column in pDt.Columns)
                    {
                        //동일 문자 또는 동일 타입이 아니면 (대,소문자 구분없이 문자열을 비교한다.)
                        if (string.Compare(prop.Name, column.ColumnName, StringComparison.CurrentCultureIgnoreCase) != 0 && prop.GetType() != column.DataType)
                            continue;
                        else
                            compareCount++;
                    }
                }

                //데이터 테이블의 컬럼 갯수와 체크 카운트의 프로퍼티 갯수가 다르면 익셉션
                if (pDt.Columns.Count != compareCount)
                {
                    new Exception("DataTable 형태와 변경될 object 형태가 다릅니다.");
                }

                foreach (DataRow dr in pDt.Rows)
                {
                    T tObject = new T();
                    foreach (var prop in properties)
                    {
                        prop.SetValue(tObject, dr[prop.Name]);
                    }

                    listObject.Add(tObject);
                }

                return listObject;
            }
            catch
            {
                //로그 남기기
                return null;
            }
        }

        /// <summary>
        /// object -> DataTable Convert Extension Method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable GenericToDataTable<T>(this List<T> items) 
        {
            try
            {
                System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
                DataTable returnDT = new DataTable();

                foreach (var prop in properties)
                {
                    returnDT.Columns.Add(prop.Name, prop.PropertyType);
                }

                //Fill the DataTable
                foreach (var item in items)
                {
                    DataRow dr = returnDT.NewRow();

                    foreach (var prop in properties)
                    {
                        var itemValue = prop.GetValue(item, new object[] { });
                        dr[prop.Name] = itemValue;
                    }

                    returnDT.Rows.Add(dr);
                }

                return returnDT;
            }
            catch
            {
                return null;
            }
        }

        ///// <summary>
        ///// object -> DataTable Convert Normal Method
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="items"></param>
        ///// <returns></returns>
        //public static DataTable GenericToDataTable<T>(List<T> items) 
        //{
        //    try
        //    {
        //        System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
        //        DataTable returnDT = new DataTable();

        //        foreach (var prop in properties)
        //        {
        //            returnDT.Columns.Add(prop.Name, prop.PropertyType);
        //        }

        //        //Fill the DataTable
        //        foreach (var item in items)
        //        {
        //            DataRow dr = returnDT.NewRow();

        //            foreach (var prop in properties)
        //            {
        //                var itemValue = prop.GetValue(item, new object[] { });
        //                dr[prop.Name] = itemValue;
        //            }

        //            returnDT.Rows.Add(dr);
        //        }

        //        return returnDT;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// Reader To Generic (리더의 정보를 제네릭 형태로 변경하여 리턴한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public static List<T> ReaderToGenericList<T>(IDataReader pReader) where T : class , new() 
        {
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();//반환된 정보

            List<T> listObj = new List<T>();

            while (pReader.Read())
            {
                T obj = new T();

                for (int i = 0; i < pReader.FieldCount; i++)
                {
                    foreach (var prop in properties)
                    {
                        if (prop.Name == pReader.GetName(i))
                        {
                            Type test = prop.GetType();

                            prop.SetValue(obj, pReader[i]);
                        }
                    }
                }

                listObj.Add(obj);
            }

            return listObj;
        }

        /// <summary>
        /// Reader To Generic (리더의 정보를 제네릭 형태로 변경하여 리턴한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public static T ReaderToGeneric<T>(IDataReader pReader) where T : class , new() 
        {
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();//반환된 정보

            T obj = new T();

            while (pReader.Read())
            {
                for (int i = 0; i < pReader.FieldCount; i++)
                {
                    foreach (var prop in properties)
                    {
                        if (prop.Name == pReader.GetName(i))
                        {
                            Type test = prop.GetType();

                            prop.SetValue(obj, pReader[i]);
                        }
                    }
                }
            }

            return obj;
        }

    }
}