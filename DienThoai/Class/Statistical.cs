using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace DienThoai.Class
{
    internal class Statistical
    {
        QuanLyDienThoai ds = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        
        public int ThongKeSoTaiKhoan()
        {
            cnn.Open();
            string s = "Select count(*) from TAIKHOAN";
            SqlCommand cmd = new SqlCommand(s, cnn);
            int kq = int.Parse(cmd.ExecuteScalar().ToString());
            cnn.Close();
            return kq;
        }
        public int ThongKeSoNhaCungCap()
        {
            cnn.Open();
            string s = "Select count(*) from NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(s, cnn);
            int kq = int.Parse(cmd.ExecuteScalar().ToString());
            cnn.Close();
            return kq;
        }
        public int ThongKeSoSanPham()
        {
            cnn.Open();
            string s = "Select count(*) from DIENTHOAI";
            SqlCommand cmd = new SqlCommand(s, cnn);
            int kq = int.Parse(cmd.ExecuteScalar().ToString());
            cnn.Close();
            return kq;
        }

        /*public DataTable HienThiThongKeSanPham()
        {
            cnn.Open();
            string s = "select DIENTHOAI.MADIENTHOAI, TENDIENTHOAI, CHITIETPHIEUNHAP.SOLUONGNHAP, CHITIETPHIEUXUAT.SOLUONGXUAT from DIENTHOAI INNER JOIN CHITIETPHIEUNHAP ON DIENTHOAI.MADIENTHOAI = CHITIETPHIEUNHAP.MADIENTHOAI INNER JOIN CHITIETPHIEUXUAT ON DIENTHOAI.MADIENTHOAI = CHITIETPHIEUXUAT.MADIENTHOAI";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }*/
        public DataTable ThongKeNhapXuat()
        {
            string s = "select DIENTHOAI.MADIENTHOAI, DIENTHOAI.TENDIENTHOAI, SUM(SOLUONGNHAP) as N'Số lượng nhập', SUM(SOLUONGXUAT) as N'Số lượng xuất' from DIENTHOAI, CHITIETPHIEUNHAP, CHITIETPHIEUXUAT where DIENTHOAI.MADIENTHOAI = CHITIETPHIEUNHAP.MADIENTHOAI and DIENTHOAI.MADIENTHOAI = CHITIETPHIEUXUAT.MADIENTHOAI group by DIENTHOAI.MADIENTHOAI, DIENTHOAI.TENDIENTHOAI";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable HienThiThongKeTaiKhoan()
        {
            /*cnn.Open();*/
            string s = "select * from TAIKHOAN";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable PhieuNhap()
        {
            /*cnn.Open();*/
            string s = "SELECT * FROM PHIEUNHAP";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string TenNhaCungCap(string Ma)
        {
            cnn.Open();
            string s = "Select TENNHACUNGCAP from NHACUNGCAP where MANHACUNGCAP = '" + Ma + "'";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return kq;
        }
        public DataTable PhieuXuat()
        {
            string s = "select * from PHIEUXUAT";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
    }
}
