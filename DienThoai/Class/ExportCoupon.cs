using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ExportCoupon
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiPhieuXuat()
        {
            string s = "select * from PHIEUXUAT";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaPhieuXuat(string MaPhieu)
        {
            string s = "delete from PHIEUXUAT where MAPHIEU = '" + MaPhieu + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaChiTietPhieuXuat(string MaPhieu)
        {
            string s = "delete from CHITIETPHIEUXUAT where MAPHIEU = '" + MaPhieu + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string ThemPhieuXuat_Excel(string Maphieu, DateTime Thoigiantao, string Nguoitao, string Tongtien)
        {
            c.Open();
            string s = "insert into PHIEUXUAT values ('" + Maphieu + "', '" + Thoigiantao + "', '" + Nguoitao + "','" + Tongtien + "')";
            var cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
    }
}
