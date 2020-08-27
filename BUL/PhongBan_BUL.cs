using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUL
{
    public class PhongBan_BUL
    {
        private PhongBan_DAL phongBan_DAL = new PhongBan_DAL();
        public DataTable getAllPhongBan()
        {
            return phongBan_DAL.getAllPhongBan();
        }
    }
}
