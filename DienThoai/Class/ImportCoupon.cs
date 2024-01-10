using DienThoai.Menu;
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
    internal class ImportCoupon
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiPhieuNhap()
        {
            string s = "SELECT * FROM PHIEUNHAP";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaPhieuNhap(string MaPhieu)
        {
            string s = "delete from PHIEUNHAP where MAPHIEU = '" + MaPhieu + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaChiTietPhieuNhap(string MaPhieu)
        {
            string s = "delete from CHITIETPHIEUNHAP where MAPHIEU = '" + MaPhieu + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string TenNhaCungCap(string Ma)
        {
            c.Open();
            string s = "Select TENNHACUNGCAP from NHACUNGCAP where MANHACUNGCAP = '" + Ma + "'";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
        public string ThemPhieuNhap_Excel(string Maphieu, DateTime Thoigiantao, string Nguoitao, string Manhacungcap, string Tongtien)
        {
            c.Open();
            string s = "insert into PHIEUNHAP values ('" + Maphieu + "', '" + Thoigiantao + "', '" + Nguoitao + "','" + Manhacungcap + "','" + Tongtien + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
    }
}
