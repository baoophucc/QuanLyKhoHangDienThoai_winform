using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class Login
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public bool KiemTraDangNhap(string taikhoan, string matkhau)
        {
            bool kt = false;
            string TaiKhoan = taikhoan;
            string MatKhau = matkhau;
            string s = "Select * from TAIKHOAN";
            SqlCommand cmd = new SqlCommand(s, c);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (TaiKhoan == dr.GetString(0) && MatKhau == dr.GetString(1))
                {
                    kt = true;
                    break;
                }
            }
            c.Close();
            return kt;
        }
    }
}
