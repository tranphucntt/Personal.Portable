using ConnectionLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOB
{
    public class DBDataOperateService
    {
        public DBDataChangeService dbDataChangeService;

        public DBDataOperateService()
        {
            dbDataChangeService = new DBDataChangeService();
        }

        public string ConnectionString { get; set; }

        /// <summary>
        /// Get data enumerable
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="Contents"></param>
        /// <returns></returns>
        public List<DataRow> GetDataEnumerable(string SPName, object Contents)
        {
            SqlParameter[] arrPara = Contents != null ? dbDataChangeService.ObjectToSqlParameter(Contents) : null;

            MSSQL ms = new MSSQL(ConnectionString);

            return ms.GetDSForSP(SPName, arrPara).Tables[0].AsEnumerable().ToList();
        }
    }
}