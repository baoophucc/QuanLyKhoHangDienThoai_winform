using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class Inventory
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DataTable HienThiTonKho()
        {
            string s = "select * from DIENTHOAI";
            da = new SqlDataAdapter(s, c);
            da.Fill(dt, "DIENTHOAI");
            DataColumn[] dc = new DataColumn[1];
            dc[0] = dt.Tables["DIENTHOAI"].Columns[0];
            dt.Tables["DIENTHOAI"].PrimaryKey = dc;
            return dt.Tables["DIENTHOAI"];
        }
    }
}
