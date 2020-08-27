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
    public class ChucVu_BUL
    {
        private ChucVu_DAL cv = new ChucVu_DAL();
        public DataTable getAllChucVu()
        {
            return cv.getAllChucVu();
        }
        public int insertChucVu(ChucVu_DTO c)
        {
            return cv.insertChucVu(c);
        }
        public int updateChucVu(ChucVu_DTO c) {
            return cv.updateChucVu(c);
        }
        public int deleteChucVu(ChucVu_DTO c) {
            return cv.deleteChucVu(c);
        }

    }
}
