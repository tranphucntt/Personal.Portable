using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionLib
{
    /// <summary>
    /// 資料擷取基本設定
    /// </summary>
    public class baseBasic
    {
        /// <summary>
        /// MSSQL資料庫連線
        /// </summary>
        public SqlConnection baseConnection { get; set; }

        /// <summary>
        /// MSSQL指令碼
        /// </summary>
        public SqlCommand baseCommand { get; set; }

        /// <summary>
        /// MSSQL資料連接
        /// </summary>
        public SqlDataAdapter baseDA { get; set;  }

        /// <summary>
        /// 網路連接字串
        /// </summary>
        public string baseConnectionString { get; set;}

        /// <summary>
        /// 資料集
        /// </summary>
        public DataSet baseDS { get; set; }
        
    }
}
