using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BOB
{
    public class DBDataChangeService
    {
        /// <summary>
        /// Object to sqlparameter array
        /// </summary>
        /// <param name="Contents"></param>
        /// <returns></returns>
        public SqlParameter[] ObjectToSqlParameter(object Contents)
        {
            Dictionary<string, object> dicSource =
               Contents.GetType()
                .GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.Public
                )
                .ToDictionary(
                    prop => prop.Name,
                    prop => prop.GetValue(Contents, null)
                );

            SqlParameter[] arrPara = new SqlParameter[dicSource.Count];

            int i = 0;
            foreach (KeyValuePair<string, object> kvp in dicSource)
            {
                arrPara[i] = new SqlParameter(kvp.Key, kvp.Value == null ? "" : kvp.Value.ToString());
                i++;
            }

            return arrPara;
        }
    }
}