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
using DTO;
using System.Net.Mail;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

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
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.NgaySinh = dtpNgaySinh.Text;
            if (rdbNam.Checked)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
           
                nv.SDT = txtSDT.Text;
            

            nv.Email = txtEmail.Text;
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            if (CBQuyen.Checked)
            {
                nv.Quyen = true;
            }
            else
            {
                nv.Quyen = false;
            }
            nv.MaPB = cbbMaPB.SelectedValue.ToString();
            nv.MaCV = cbbMaCV.SelectedValue.ToString();
            DataTable dt= nhanVien_BUL.findNhanVien(nv);
            dtgNhanVien.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.NgaySinh = dtpNgaySinh.Text;
            if (rdbNam.Checked)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.SDT = txtSDT.Text;
            nv.Email = txtEmail.Text;
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            if (CBQuyen.Checked)
            {
                nv.Quyen = true;
            }
            else
            {
                nv.Quyen = false;
            }
            nv.MaPB = cbbMaPB.SelectedValue.ToString();
            nv.MaCV = cbbMaCV.SelectedValue.ToString();
            int kq = nhanVien_BUL.insertNhanVien(nv);           
            HienThi();
        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNV.Text = dtgNhanVien.Rows[row].Cells[0].Value.ToString();
                txtTenNV.Text = dtgNhanVien.Rows[row].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dtgNhanVien.Rows[row].Cells[2].Value.ToString();
                if (dtgNhanVien.Rows[row].Cells[3].Value.Equals("Nam"))
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }
                txtSDT.Text = dtgNhanVien.Rows[row].Cells[4].Value.ToString();
                txtEmail.Text = dtgNhanVien.Rows[row].Cells[5].Value.ToString();
                txtTaiKhoan.Text = dtgNhanVien.Rows[row].Cells[6].Value.ToString();
                txtMatKhau.Text = dtgNhanVien.Rows[row].Cells[7].Value.ToString();
                if (dtgNhanVien.Rows[row].Cells[8].Value.Equals(true))
                {
                    CBQuyen.Checked = true;
                }
                else
                {
                    CBQuyen.Checked = false;
                }
                
                cbbMaPB.Text = dtgNhanVien.Rows[row].Cells[9].Value.ToString();
                cbbMaCV.Text = dtgNhanVien.Rows[row].Cells[10].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.NgaySinh = dtpNgaySinh.Text;
            if (rdbNam.Checked)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.SDT = txtSDT.Text;
            nv.Email = txtEmail.Text;
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            if (CBQuyen.Checked)
            {
                nv.Quyen = true;
            }
            else
            {
                nv.Quyen = false;
            }
            nv.MaPB = cbbMaPB.SelectedValue.ToString();
            nv.MaCV = cbbMaCV.SelectedValue.ToString();
            int kq = nhanVien_BUL.updateNhanVien(nv);
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int kq = nhanVien_BUL.deleteNhanVien(txtMaNV.Text);
            HienThi();
        }

        private void btnInDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dtgNhanVien.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dtgNhanVien.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dtgNhanVien.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }
    }  

       
}
