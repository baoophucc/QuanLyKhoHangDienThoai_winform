using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class Account
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        static string UserName;
        public static string username
        {
            get
            {
                return username;
            }
            set
            {
                UserName = value;
            }
        }
        public DataTable HienThiTaiKhoan()
        {
            string s = "select * from TAIKHOAN";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable XoaTaiKhoan(string ttk)
        {
            string s = "delete from TAIKHOAN where TENTAIKHOAN = '" + ttk + "'";
            var cmd = new SqlCommand(s, c);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public string HienThiEmail(string ttk)
        {
            c.Open();
            string s = "select EMAIL from TAIKHOAN where TENTAIKHOAN = '" + ttk + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
        public string HienThiHovaTen(string ttk)
        {
            c.Open();
            string s = "select HOVATEN from TAIKHOAN where TENTAIKHOAN = '" + ttk + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
        public string CapNhatMatKhau(string matkhau, string ttk)
        {
            c.Open();
            string s = "update TAIKHOAN set MATKHAU = '" + matkhau + "' where TENTAIKHOAN = '" + ttk + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string ThemTaiKhoan(string ttk, string mk, string ht, string vt, string email)
        {
            c.Open();
            string s = "insert into TAIKHOAN values ('" + ttk + "', '" + mk + "', N'" + ht + "', N'" + vt + "', '" + email + "')";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public string ThemTaiKhoan_Excel(string ttk, string mk, string ht, string vt, string email)
        {
            c.Open();
            string s = "insert into TAIKHOAN values ('" + ttk + "', '" + mk + "', N'" + ht + "', N'" + vt + "', '" + email + "')";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public bool KiemTraTonTaiTenTaiKhoan(string ttk)
        {
            bool kt = false;
            string manhacungcap = ttk;
            string s = "Select * from TAIKHOAN";
            SqlCommand cmd = new SqlCommand(s, c);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (manhacungcap == dr.GetString(0))
                {
                    kt = true;
                    break;
                }
            }
            c.Close();
            return kt;
        }
        /*public bool CapNhatTaiKhoan(string Ten, string MatKhau, string HoTen, string Email)
        {
            try
            {
                DataRow dr = dt.Tables["TAIKHOAN"].Rows.Find(Ten);
                if (dr != null)
                {
                    dr["MATKHAU"] = MatKhau;
                    dr["HOVATEN"] = HoTen;
                    dr["EMAIL"] = Email;
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "TAIKHOAN");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
        public string CapNhatTaiKhoan(string ttk, string mk, string ht, string email)
        {
            c.Open();
            string s = "update TAIKHOAN set MATKHAU = '" + mk + "', HOVATEN = N'" + ht + "', EMAIL = '" + email + "' where TENTAIKHOAN = '" + ttk + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }
        public bool KiemTraTonTaiEmail(string em)
        {
            bool kt = false;
            string email = em;
            string s = "Select * from TAIKHOAN";
            SqlCommand cmd = new SqlCommand(s, c);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (email == dr.GetString(3))
                {
                    kt = true;
                    break;
                }
            }
            c.Close();
            return kt;
        }
        public bool KiemTraKhoaNgoaiTaiKhoan(string tk)
        {
            bool kt = false;
            string taikhoan = tk;
            string s = "Select * from PHIEUNHAP, PHIEUXUAT";
            SqlCommand cmd = new SqlCommand(s, c);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (taikhoan == dr.GetString(2))
                {
                    kt = true;
                    break;
                }
            }
            c.Close();
            return kt;
        }
        public string VaiTro(string ttk)
        {
            c.Open();
            string s = "select VAITRO from TAIKHOAN where TENTAIKHOAN = '" + ttk + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteScalar().ToString();
            c.Close();
            return kq;
        }
    }
}
