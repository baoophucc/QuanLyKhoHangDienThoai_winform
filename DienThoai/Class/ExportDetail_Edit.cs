using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ExportDetail_Edit
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
        public DataTable HienThiPhieuXuat(string mp)
        {
            string s = "select CHITIETPHIEUXUAT.MADIENTHOAI, DIENTHOAI.TENDIENTHOAI, SOLUONGXUAT, DONGIA from DIENTHOAI inner join CHITIETPHIEUXUAT on DIENTHOAI.MADIENTHOAI = CHITIETPHIEUXUAT.MADIENTHOAI where MAPHIEU = '" + mp + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaChiTietPhieuXuat(string mp)
        {
            string s = "delete from CHITIETPHIEUXUAT where MAPHIEU = '" + mp + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string ThemChiTietPhieuXuat(string mp, string mdt, string sln, string dg)
        {
            c.Open();
            string s = "INSERT INTO CHITIETPHIEUXUAT VALUES ('" + mp + "', '" + mdt + "', '" + sln + "', '" + dg + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string CapNhatTongTien(string tongtien, string maphieu)
        {
            c.Open();
            string s = "update PHIEUXUAT set TONGTIEN = '" + tongtien + "' where MAPHIEU = '" + maphieu + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        //SỬA THÔNG TIN PHIẾU XUẤT
        public string SoLuongBanDau(string soluong, string madienthoai)
        {
            c.Open();
            string s = "update DIENTHOAI set SOLUONG = SOLUONG + '" + soluong + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string GiamSoLuong(string soluong, string madienthoai)
        {
            c.Open();
            string s = "update DIENTHOAI set SOLUONG = SOLUONG - '" + soluong + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string CapNhatSoLuong(string soluong_cu, string soluong_moi, string madienthoai)
        {
            c.Open();
            string s = "update DIENTHOAI set SOLUONG = (SOLUONG + '" + soluong_cu + "') - '" + soluong_moi + "' WHERE MADIENTHOAI = '" + madienthoai + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
    }
}
