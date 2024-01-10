using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace DienThoai
{
    internal class Supplier
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiNhaCungCap()
        {
            string s = "select * from NHACUNGCAP";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            cnn.Close();
            return dt;
        }
        /*public bool KiemTraHopLeSoDienThoai(string PhoneNumber)
        {
            string Format = @"^(09|03|08|07|05|028)+([0-9]{8})$";
            return Regex.IsMatch(PhoneNumber, Format);
        }*/
        public bool KiemTraTonTaiMaNhaCungCap(string mncc)
        {
            bool kt = false;
            string manhacungcap = mncc;
            string s = "Select * from NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (manhacungcap == dr.GetString(0))
                {
                    kt = true;
                    break;
                }
            }
            cnn.Close();
            return kt;
        }
        public bool KiemTraKhoaNgoaiNhaCungCap(string mncc)
        {
            bool kt = false;
            string manhacungcap = mncc;
            string s = "Select * from PHIEUNHAP";
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (manhacungcap == dr.GetString(3))
                {
                    kt = true;
                    break;
                }
            }
            cnn.Close();
            return kt;
        }
        /*public bool XoaNhaCungCap(string MaNhaCungCap)
        {
            try
            {
                DataRow dr = dt.Tables["NHACUNGCAP"].Rows.Find(MaNhaCungCap);
                if (dr != null)
                {
                    dr.Delete();
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "NHACUNGCAP");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
        public string XoaNhaCungCap(string Ma)
        {
            cnn.Open();
            string s = "delete from NHACUNGCAP where MANHACUNGCAP = '" + Ma + "'";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        /*public bool ThemNhaCungCap(string Ma, string Ten, string Sdt, string DiaChi)
        {
            try
            {
                DataRow dr = dt.Tables["NHACUNGCAP"].Rows.Find(Ma);
                if (dr != null)
                {
                    return false;
                }
                else
                {
                    DataRow dr2 = dt.Tables["NHACUNGCAP"].NewRow();
                    dr2["MANHACUNGCAP"] = Ma;
                    dr2["TENNHACUNGCAP"] = Ten;
                    dr2["SODIENTHOAI"] = Sdt;
                    dr2["DIACHI"] = DiaChi;
                    dt.Tables["NHACUNGCAP"].Rows.Add(dr2);
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "NHACUNGCAP");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
        /*public bool CapNhatNhaCungCap(string Ma, string Ten, string Sdt, string DiaChi)
        {
            try
            {
                DataRow dr = dt.Tables["NHACUNGCAP"].Rows.Find(Ma);
                if (dr != null)
                {
                    dr["TENNHACUNGCAP"] = Ten;
                    dr["SODIENTHOAI"] = Sdt;
                    dr["DIACHI"] = DiaChi;
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "NHACUNGCAP");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
        public string CapNhatNhaCungCap(string ma, string ten, string sdt, string diachi)
        {
            cnn.Open();
            string s = "update NHACUNGCAP set TENNHACUNGCAP = N'" + ten + "', SODIENTHOAI = '" + sdt + "', DIACHI = N'" + diachi + "' where MANHACUNGCAP = '" + ma + "'";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        public string ThemNhaCungCap(string ma, string ten, string sdt, string diachi)
        {
            cnn.Open();
            string s = "INSERT INTO NHACUNGCAP VALUES ('" + ma + "', N'" + ten + "', '" + sdt + "', N'" + diachi + "')";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        public string ThemNhaCungCap_Excel(string ma, string ten, string sdt, string diachi)
        {
            cnn.Open();
            string s = "INSERT INTO NHACUNGCAP VALUES ('" + ma + "', N'" + ten + "', '" + sdt + "', N'" + diachi + "')";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
    }
}
