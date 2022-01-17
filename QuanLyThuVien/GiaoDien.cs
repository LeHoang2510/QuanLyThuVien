using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class GiaoDien : Form
    {
        public GiaoDien()
        {
            InitializeComponent();
        }

        private void GiaoDien_Load(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rtx = MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rtx == DialogResult.Yes)
            {
                this.Hide();
                DangNhap DangXuat = new DangNhap();
                DangXuat.Closed += (s, args) => this.Close();
                DangXuat.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 abs = new Form1();
            abs.Show();
            this.Hide();
        }

        private void quảnLýĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 abs = new Form2();
            abs.Show();
            this.Hide();
        }
        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe abs = new BaoCaoThongKe();
            abs.Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau abs = new DoiMatKhau();
            abs.Show();
            this.Hide();
        }

        private void quảnLýTàiLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTaiLieu abs = new QLTaiLieu();
            abs.Show();
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void quảnLýMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPhieuMuon abs = new QLPhieuMuon();
            abs.Show();
            this.Hide();
        }

        private void tìmKiếmTàiLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTimKiem abs = new QLTimKiem();
            abs.Show();
            this.Hide();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemDocGia abs = new TimKiemDocGia();
            abs.Show();
            this.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien abs = new TimKiemNhanVien();
            abs.Show();
            this.Hide();
        }
    }
}
