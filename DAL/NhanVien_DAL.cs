using System;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DAL
{
    public class NhanVien_DAL
    {
        public SqlConnection getConnection()
        {
            String strconn = @"Data Source=DESKTOP-LTLQFUB;Initial Catalog=QLNhanSu;Integrated Security=True";
            return new SqlConnection(strconn);
        }
        public DataTable getAllNhanVien()
        {
            try
            {
                String sql = "select MaNV as 'Mã nhân viên', TenNV as'Tên nhân viên', NgaySinh as'Ngay Sinh', GioiTinh as'Giới Tính', SDT as'Số điện thoại'" +
                    ",Email, TaiKhoan as'Tài khoản', MatKhau as'Mật khẩu', Quyen as'Quyền', TenPB as'Tên phòng ban',TenCV as'Tên chức vụ' from NhanVien join PHONGBAN on NHANVIEN.MaPB=PHONGBAN.MAPB join CHUCVU on nhanvien.macv=chucvu.macv";
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
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        public int insertNhanVien(NhanVienDTO nv)
        {
            String sql = "insert into NhanVien values(@MaNV,@TenNV,@NgaySinh,@GioiTinh,@SDT,@Email, @TaiKhoan, @MatKhau, @Quyen, @MaPB,@MaCV)";
            try
            {
                SqlConnection conn = getConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@TaiKhoan", nv.TaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", nv.Quyen);
                cmd.Parameters.AddWithValue("@MaPB", nv.MaPB);
                cmd.Parameters.AddWithValue("@MaCV", nv.MaCV);
                cmd.ExecuteNonQuery();
                return 1;
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return 0;
        }
    }
}
