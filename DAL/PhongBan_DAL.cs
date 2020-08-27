using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongBan_DAL
    {
        public SqlConnection getConnection()
        {
            String strconn = @"Data Source=DESKTOP-LTLQFUB;Initial Catalog=QLNhanSu;Integrated Security=True";
            return new SqlConnection(strconn);
        }
        public DataTable getAllPhongBan()
        {
            String sql = "select * from PHONGBAN";
            SqlConnection conn = getConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
    }
}
