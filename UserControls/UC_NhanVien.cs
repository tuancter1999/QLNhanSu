using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;

namespace QLNhanSu.UserControls
{
    public partial class UC_NhanVien : UserControl
    {
        private NhanVien_BUL nhanVien_BUL = new NhanVien_BUL();
        private PhongBan_BUL phongBan_BUL = new PhongBan_BUL();
        private ChucVu_BUL chucVu_BUL = new ChucVu_BUL();
        public UC_NhanVien()
        {
            InitializeComponent();
        }
        private void HienThi()
        {
            DataTable dt = nhanVien_BUL.getAllNhanVien();
            dtgNhanVien.DataSource = dt;
        }
        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            HienThi();
            DataTable dt = phongBan_BUL.getAllPhongBan();
            cbbMaPB.DataSource = dt;
            cbbMaPB.ValueMember = "MaPB";
            cbbMaPB.DisplayMember = "TenPB";
            DataTable dt1 = chucVu_BUL.getAllChucVu();
            cbbMaCV.DataSource = dt1;
            cbbMaCV.ValueMember = "MaCV";
            cbbMaCV.DisplayMember = "TenCV";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
        }
    }  

       
}
