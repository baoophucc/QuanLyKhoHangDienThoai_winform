using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ExportDetail
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiChiTietPhieuXuat(string mp)
        {
            string s = "SELECT CHITIETPHIEUXUAT.MADIENTHOAI, TENDIENTHOAI, SOLUONGXUAT, DONGIA FROM CHITIETPHIEUXUAT INNER JOIN DIENTHOAI ON CHITIETPHIEUXUAT.MADIENTHOAI = DIENTHOAI.MADIENTHOAI where MAPHIEU = '" + mp + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
    }
}
