using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ImportDetail_Edit
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiDienThoai()
        {
            string s = "select MADIENTHOAI, TENDIENTHOAI, SOLUONG, GIA from DIENTHOAI";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable HienThiPhieuNhap(string mp)
        {
            string s = "select CHITIETPHIEUNHAP.MADIENTHOAI, DIENTHOAI.TENDIENTHOAI, SOLUONGNHAP, DONGIA from DIENTHOAI inner join CHITIETPHIEUNHAP on DIENTHOAI.MADIENTHOAI = CHITIETPHIEUNHAP.MADIENTHOAI where MAPHIEU = '" + mp + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaChiTietPhieuNhap(string mp)
        {
            string s = "delete from CHITIETPHIEUNHAP where MAPHIEU = '" + mp + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
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
        
        public string CapNhatPhieuNhap(string tongtien, string macungcap, string maphieu)
        {
            c.Open();
            string s = "update PHIEUNHAP set TONGTIEN = '" + tongtien + "', MANHACUNGCAP = '" + macungcap + "' where MAPHIEU = '" + maphieu + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string HienThiMaCungCap(string ten)
        {
            c.Open();
            string s = "select MANHACUNGCAP from NHACUNGCAP where TENNHACUNGCAP = '" + ten + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
        public DataTable HienThiNhaCungCap()
        {
            string s = "select * from NHACUNGCAP";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        //SỬA THÔNG TIN PHIẾU NHẬP
        public string SoLuongBanDau(string soluong, string madienthoai)
        {
            c.Open();
            string s = "update DIENTHOAI set SOLUONG = SOLUONG - '" + soluong + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string ThemSoLuong(string soluong, string madienthoai)
        {
            c.Open();
            string s = "update DIENTHOAI set SOLUONG = SOLUONG + '" + soluong + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string CapNhatSoLuong(string soluong_cu, string soluong_moi, string madienthoai)
        {
            c.Open();
            string s = "update DIENTHOAI set SOLUONG = (SOLUONG - '" + soluong_cu + "') + '" + soluong_moi + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
    }
}
