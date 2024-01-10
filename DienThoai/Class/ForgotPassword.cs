using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ForgotPassword
    {
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public bool KiemTraEmail(string email)
        {
            bool kt = false;
            string Email = email;
            string s = "Select * from TAIKHOAN";
            SqlCommand cmd = new SqlCommand(s, c);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Email == dr.GetString(4))
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
