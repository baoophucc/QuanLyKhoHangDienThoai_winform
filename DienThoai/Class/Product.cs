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
    internal class Product
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiSanPham()
        {
            string s = "select * from DIENTHOAI";
            var cmd = new SqlCommand(s, cnn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            cnn.Close();
            return dt;
        }
        public bool KiemTraTonTaiMaDienThoai(string sp)
        {
            bool kt = false;
            string sanpham = sp;
            string s = "Select * from DIENTHOAI";
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (sanpham == dr.GetString(0))
                {
                    kt = true;
                    break;
                }
            }
            cnn.Close();
            return kt;
        }
        public bool KiemTraKhoaNgoaiSanPham(string mdt)
        {
            bool kt = false;
            string madienthoai = mdt;
            string s = "Select * from CHITIETPHIEUNHAP, CHITIETPHIEUXUAT";
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (madienthoai == dr.GetString(1))
                {
                    kt = true;
                    break;
                }
            }
            cnn.Close();
            return kt;
        }
        /*public bool ThemDienThoai(string Ma, string Ten, string Cnmh, string Ktmh, string Dpg, string Hdh, string Ct, string Cs, string Chip, string Ram, string Rom, string Sim, string Pin, string Sac, string Xx, string Sl, string Dg)
        {
            try
            {
                DataRow dr = dt.Tables["DIENTHOAI"].Rows.Find(Ma);
                if (dr != null)
                {
                    return false;
                }
                else
                {
                    DataRow dr_new = dt.Tables["DIENTHOAI"].NewRow();
                    dr_new["MADIENTHOAI"] = Ma;
                    dr_new["TENDIENTHOAI"] = Ten;
                    dr_new["CONGNGHEMANHINH"] = Cnmh;
                    dr_new["KICHTHUOCMANHINH"] = Ktmh;
                    dr_new["DOPHANGIAI"] = Dpg;
                    dr_new["HEDIEUHANH"] = Hdh;
                    dr_new["CAMTRUOC"] = Ct;
                    dr_new["CAMSAU"] = Cs;
                    dr_new["CHIP"] = Chip;
                    dr_new["RAM"] = Ram;
                    dr_new["DUNGLUONGLUUTRU"] = Rom;
                    dr_new["SIM"] = Sim;
                    dr_new["DUNGLUONGPIN"] = Pin;
                    dr_new["SAC"] = Sac;
                    dr_new["XUATXU"] = Xx;
                    dr_new["SOLUONG"] = Sl;
                    dr_new["GIA"] = Dg;
                    dt.Tables["DIENTHOAI"].Rows.Add(dr_new);
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "DIENTHOAI");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
        public string ThemDienThoai(string Ma, string Ten, string Cnmh, string Ktmh, string Dpg, string Hdh, string Ct, string Cs, string Chip, string Ram, string Rom, string Sim, string Pin, string Sac, string Xx, string Sl, string Dg)
        {
            cnn.Open();
            string s = "INSERT INTO DIENTHOAI VALUES ('" + Ma + "', N'" + Ten + "', '" + Cnmh + "', '" + Ktmh + "', '" + Dpg + "', '" + Hdh + "', '" + Ct + "', '" + Cs + "', '" + Chip + "', '" + Ram + "', '" + Rom + "', '" + Sim + "', '" + Pin + "', '" + Sac + "', N'" + Xx + "', '" + Sl + "', '" + Dg + "')";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        public string ThemDienThoai_Excel(string Ma, string Ten, string Cnmh, string Ktmh, string Dpg, string Hdh, string Ct, string Cs, string Chip, string Ram, string Rom, string Sim, string Pin, string Sac, string Xx, string Sl, string Dg)
        {
            cnn.Open();
            string s = "INSERT INTO DIENTHOAI VALUES ('" + Ma + "', N'" + Ten + "', '" + Cnmh + "', '" + Ktmh + "', '" + Dpg + "', '" + Hdh + "', '" + Ct + "', '" + Cs + "', '" + Chip + "', '" + Ram + "', '" + Rom + "', '" + Sim + "', '" + Pin + "', '" + Sac + "', N'" + Xx + "', '" + Sl + "', '" + Dg + "')";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        /*public bool XoaSanPham(string MaSanPham)
        {
            try
            {
                DataRow dr = dt.Tables["DIENTHOAI"].Rows.Find(MaSanPham);
                if (dr != null)
                {
                    dr.Delete();
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "DIENTHOAI");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
        public string XoaDienThoai(string Ma)
        {
            cnn.Open();
            string s = "delete from DIENTHOAI where MADIENTHOAI = '" + Ma + "'";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        public string CapNhatDienThoai(string Ma, string Ten, string Cnmh, string Ktmh, string Dpg, string Hdh, string Ct, string Cs, string Chip, string Ram, string Rom, string Sim, string Pin, string Sac, string Xx, string Sl, string Dg)
        {
            cnn.Open();
            string s = "update DIENTHOAI set TENDIENTHOAI = N'" + Ten + "', CONGNGHEMANHINH = '" + Cnmh + "', KICHTHUOCMANHINH = '" + Ktmh + "', DOPHANGIAI = '" + Dpg + "', HEDIEUHANH = '" + Hdh + "', CAMTRUOC = '" + Ct + "', CAMSAU = '" + Cs + "', CHIP = '" + Chip + "', RAM = '" + Ram + "', DUNGLUONGLUUTRU = '" + Rom + "', SIM = '" + Sim + "', DUNGLUONGPIN = '" + Pin + "', SAC = '" + Sac + "', XUATXU = N'" + Xx + "', SOLUONG = '" + Sl + "', GIA = '" + Dg + "' where MADIENTHOAI = '" + Ma + "'";
            var cmd = new SqlCommand(s, cnn);
            string kq = cmd.ExecuteNonQuery().ToString();
            cnn.Close();
            return kq;
        }
        /*public bool CapNhatDienThoai(string Ma, string Ten, string Cnmh, string Ktmh, string Dpg, string Hdh, string Ct, string Cs, string Chip, string Ram, string Rom, string Sim, string Pin, string Sac, string Xx, string Sl, string Dg)
        {
            try
            {
                DataRow dr = dt.Tables["DIENTHOAI"].Rows.Find(Ma);
                if (dr != null)
                {
                    dr["MADIENTHOAI"] = Ma;
                    dr["TENDIENTHOAI"] = Ten;
                    dr["CONGNGHEMANHINH"] = Cnmh;
                    dr["KICHTHUOCMANHINH"] = Ktmh;
                    dr["DOPHANGIAI"] = Dpg;
                    dr["HEDIEUHANH"] = Hdh;
                    dr["CAMTRUOC"] = Ct;
                    dr["CAMSAU"] = Cs;
                    dr["CHIP"] = Chip;
                    dr["RAM"] = Ram;
                    dr["DUNGLUONGLUUTRU"] = Rom;
                    dr["SIM"] = Sim;
                    dr["DUNGLUONGPIN"] = Pin;
                    dr["SAC"] = Sac;
                    dr["XUATXU"] = Xx;
                    dr["SOLUONG"] = Sl;
                    dr["GIA"] = Dg;
                    dt.Tables["DIENTHOAI"].Rows.Add(dr);
                    SqlCommandBuilder buider = new SqlCommandBuilder(da);
                    da.Update(dt, "DIENTHOAI");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/
    }
}
