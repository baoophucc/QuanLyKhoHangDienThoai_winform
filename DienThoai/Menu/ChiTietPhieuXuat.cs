using DienThoai.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DienThoai.Menu
{
    public partial class ChiTietPhieuXuat : Form
    {
        ExportDetail ed = new ExportDetail();
        public ChiTietPhieuXuat()
        {
            InitializeComponent();
        }

        private void ChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            dgvChiTietPhieuXuat.ClearSelection();
            dgvChiTietPhieuXuat.DataSource = ed.HienThiChiTietPhieuXuat(lblMaPhieu.Text);
            for (int i = 0; i < dgvChiTietPhieuXuat.Rows.Count; i++)
            {
                double temp = double.Parse(dgvChiTietPhieuXuat.Rows[i].Cells[4].Value.ToString()) * double.Parse(dgvChiTietPhieuXuat.Rows[i].Cells[5].Value.ToString());
                dgvChiTietPhieuXuat.Rows[i].Cells["THANHTIEN"].Value = temp;
                dgvChiTietPhieuXuat.Columns["THANHTIEN"].DefaultCellStyle.Format = "#,##0";
                dgvChiTietPhieuXuat.Columns["DONGIA"].DefaultCellStyle.Format = "#,##0";
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }

        private void dgvChiTietPhieuXuat_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvChiTietPhieuXuat.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            Print(this.pnlPrint);
        }
        private Bitmap b;
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            pnlPrint = pnl;
            getprintarea(pnl);
            printPreviewDialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printPreviewDialog.ShowDialog();
        }
        private void getprintarea(Panel pnl)
        {
            b = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(b, new Rectangle(0, 0, pnl.Width, pnl.Height));

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle r = e.PageBounds;
            e.Graphics.DrawImage(b, (r.Width / 2) - (this.pnlPrint.Width / 2), this.pnlPrint.Location.Y);
        }
    }
}
