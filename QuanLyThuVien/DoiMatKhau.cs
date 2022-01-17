using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyThuVien
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        string chuoiKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlCommand myCommand;
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
        private void ckbMKCU_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMKCU.Checked)
            {
                txtMKCU.UseSystemPasswordChar = false;

            }
            else
            {
                txtMKCU.UseSystemPasswordChar = true;

            }
        }

        private void ckbMKMOI_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMKMOI.Checked)
            {
                txtMKMOI.UseSystemPasswordChar = false;
            }
            else
                txtMKMOI.UseSystemPasswordChar = true;

        }

        private void ckbXNMKMOI_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbXNMKMOI.Checked)
            {
                txtXNMKMOI.UseSystemPasswordChar = false;
            }
            else
                txtXNMKMOI.UseSystemPasswordChar = true;

        }
        private void btnDMK_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                errTK.SetError(txtTK, "Vui lòng nhập tài khoản !");
            }
            else
            {
                errTK.Clear();
            }

            if (txtMKCU.Text == "")
            {
                errMKCU.SetError(txtMKCU, "Vui lòng nhập mật khẩu cũ !");
            }
            else
            {
                errMKCU.Clear();
            }
            if (txtMKMOI.Text == "")
            {
                errMKMOI.SetError(txtMKMOI, "Vui lòng nhập mật khẩu mới !");
            }
            else
            {
                errMKMOI.Clear();
            }

            if (txtXNMKMOI.Text == "")
            {
                errXNMKMOI.SetError(txtXNMKMOI, "Vui lòng nhập lại mật khẩu mới !");
            }
            else
            {
                errXNMKMOI.Clear();
            }

            if (txtTK.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTK.Focus();
            }
            else if (txtMKCU.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMKCU.Focus();
            }
            else if (txtMKMOI.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMKMOI.Focus();
            }
            else if (txtXNMKMOI.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập lại mật khẩu mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXNMKMOI.Focus();
            }
            string mk1, mk2;
            mk1 = txtMKMOI.Text;
            mk2 = txtXNMKMOI.Text;
            int kq = mk1.CompareTo(mk2);
            if (txtTK.Text.Length > 0 && txtMKCU.Text.Length > 0 && txtMKMOI.Text.Length > 0 && txtXNMKMOI.Text.Length > 0)
            {
                try
                {
                    myConnection = new SqlConnection(chuoiKetNoi);
                    myConnection.Open();
                    string strCauTruyVan = "select count(*) from DangNhap where TaiKhoan=@acc and MatKhau =@pass";
                    myCommand = new SqlCommand(strCauTruyVan, myConnection);
                    myCommand.Parameters.Add(new SqlParameter("@acc", txtTK.Text));
                    myCommand.Parameters.Add(new SqlParameter("@pass", txtMKCU.Text));
                    int x = (int)myCommand.ExecuteScalar();
                    myConnection.Close();
                    if (x == 1)
                    {
                        if (kq == 0)
                        {
                            string luumk = "update DangNhap set MatKhau='" + txtMKMOI.Text + "' where TaiKhoan='" + txtTK.Text + "'";
                            myConnection = new SqlConnection(chuoiKetNoi);
                            myConnection.Open();
                            myCommand = new SqlCommand(luumk, myConnection);
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTK.Clear();
                            txtMKCU.Clear();
                            txtMKMOI.Clear();
                            txtXNMKMOI.Clear();
                            txtTK.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không khớp nhau !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMKMOI.Clear();
                            txtXNMKMOI.Clear();
                            txtMKMOI.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !\nVui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTK.Clear();
                        txtMKCU.Clear();
                        txtMKMOI.Clear();
                        txtXNMKMOI.Clear();
                        txtTK.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rtx = MessageBox.Show("Bạn có muốn thoát không ?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rtx == DialogResult.Yes)
            {
                this.Hide();
                GiaoDien Thoat = new GiaoDien();
                Thoat.Closed += (s, args) => this.Close();
                Thoat.Show();
            }
        }
    }
}
