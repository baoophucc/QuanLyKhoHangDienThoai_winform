using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class Import
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiTenNhaCungCap()
        {
            string s = "select * from NHACUNGCAP";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable HienThiSanPham()
        {
            c.Open();
            string s = "select MADIENTHOAI, TENDIENTHOAI, SOLUONG, GIA from DIENTHOAI";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            c.Close();
            return dt;
        }
        public string ThemPhieuNhap(string mp, string tg, string nt, string mcc, string tt)
        {
            c.Open();
            string s = "INSERT INTO PHIEUNHAP VALUES ('" + mp + "', '" + tg + "', '" + nt + "', '" + mcc + "', '" + tt + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string ThemChiTietPhieuNhap(string mp, string mdt, string sln, string dg)
        {
            c.Open();
            string s = "INSERT INTO CHITIETPHIEUNHAP VALUES ('" + mp + "', '" + mdt + "', '" + sln + "', '" + dg + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string MaNhaCungCap_Ten(string Ten)
        {
            c.Open();
            string s = "Select MANHACUNGCAP from NHACUNGCAP where TENNHACUNGCAP = '" + Ten + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
        public string CapNhatSoLuongSanPham(string soluong, string madienthoai)
        {
            c.Open();
            string TruyVan = "update DIENTHOAI SET SOLUONG = SOLUONG + '" + soluong + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            SqlCommand cmd = new SqlCommand(TruyVan, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
    }
}
