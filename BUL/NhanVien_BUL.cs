using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class NhanVien_BUL
    {
        private NhanVien_DAL nhanVien_DAL = new NhanVien_DAL();
        public DataTable getAllNhanVien()
        {
            return nhanVien_DAL.getAllNhanVien();
        }
        public int insertNhanVien(NhanVienDTO nv)
        {
            return nhanVien_DAL.insertNhanVien(nv);
        }
    }
}
