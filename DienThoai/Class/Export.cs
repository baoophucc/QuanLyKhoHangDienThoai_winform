using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class Export
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiSanPham()
        {
            c.Open();
            string s = "select MADIENTHOAI, TENDIENTHOAI, SOLUONG, GIA from DIENTHOAI";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string ThemChiTietPhieuXuat(string mp, string mdt, string slx, string dg)
        {
            c.Open();
            string s = "INSERT INTO CHITIETPHIEUXUAT VALUES ('" + mp + "', '" + mdt + "', '" + slx + "', '" + dg + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string ThemPhieuXuat(string mp, string tg, string nt, string tt)
        {
            string s = "INSERT INTO PHIEUXUAT VALUES ('" + mp + "', '" + tg + "', '" + nt + "', '" + tt + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string CapNhatSoLuongSanPham(string soluong, string madienthoai)
        {
            c.Open();
            string TruyVan = "update DIENTHOAI SET SOLUONG = SOLUONG - '" + soluong + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            SqlCommand cmd = new SqlCommand(TruyVan, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
    }
}
