using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ImportDetail
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiChiTietPhieuNhap(string mp)
        {
            string s = "SELECT CHITIETPHIEUNHAP.MADIENTHOAI, TENDIENTHOAI, SOLUONGNHAP, DONGIA FROM CHITIETPHIEUNHAP INNER JOIN DIENTHOAI ON CHITIETPHIEUNHAP.MADIENTHOAI = DIENTHOAI.MADIENTHOAI where MAPHIEU = '" + mp + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string HienThiTenNhaCungCap(string ma)
        {
            c.Open();
            string s = "SELECT TENNHACUNGCAP from NHACUNGCAP where MANHACUNGCAP = '" + ma + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
    }
}
