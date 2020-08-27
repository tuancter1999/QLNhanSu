using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class ChucVu_DAL
    {
        #region bài cũ
        //private static ChucVu_DAL instance;

        //public static ChucVu_DAL Instance {
        //    get { if (instance == null) instance = new ChucVu_DAL(); return instance; }
        //    private set => instance = value;
        //}
        //private ChucVu_DAL() { }
        //public DataTable getAllChucVu() {
        //    string query = "SELECT * FROM chucvu";

        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);

        //    return result;
        //}

        //public void ThemChucVu(ChucVu_DTO chucVu) {
        //    string query = "INSERT INTO chucvu values( @macv , @tencv , @hesopc )";
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}
        #endregion
        #region dataprovider
        //public DataTable ExecuteQuery(string query, object[] paramerter = null)
        //{
        //    DataTable data = new DataTable();

        //    using (SqlConnection conn = new SqlConnection(strconn))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        int i = 0;
        //        if (paramerter != null)
        //        {
        //            string[] listpara = query.Split(' ');
        //            foreach (string item in listpara)
        //            {
        //                if (item.Contains('@'))
        //                {
        //                    cmd.Parameters.AddWithValue(item, paramerter[i]);
        //                    i++;
        //                }
        //            }
        //        }
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(data);
        //        conn.Close();
        //    }
        //    return data;
        //}
        #endregion

        public SqlConnection getConnection()
        {
            string strconn = @"Data Source=DESKTOP-LTLQFUB;Initial Catalog=QLNhanSu;Integrated Security=True";
            return new SqlConnection(strconn);
        }
        public DataTable getAllChucVu()
        {
            try
            {
                String sql = "SELECT * FROM chucvu";
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
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        public int insertChucVu(ChucVu_DTO c)
        {
            String sql = "INSERT INTO chucvu VALUES (@macv, @tencv, @hesopc)";
            try
            {
                SqlConnection conn = getConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@macv", c.Macv);
                cmd.Parameters.AddWithValue("@tencv", c.Tencv);
                cmd.Parameters.AddWithValue("@hesopc", c.Hesopc);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return 0;
        }

        public int updateChucVu(ChucVu_DTO c)
        {
            String sql = "UPDATE chucvu SET tencv = @tencv, hesopc = @hesopc WHERE macv = @macv";
            try
            {
                SqlConnection conn = getConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tencv", c.Tencv);
                cmd.Parameters.AddWithValue("@hesopc", c.Hesopc);
                cmd.Parameters.AddWithValue("@macv", c.Macv);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return 0;
        }
        public int deleteChucVu(ChucVu_DTO c)
        {
            String sql = "DELETE FROM chucvu WHERE macv = @macv";
            try
            {
                SqlConnection conn = getConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@macv", c.Macv);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return 0;
        }
    }
}
