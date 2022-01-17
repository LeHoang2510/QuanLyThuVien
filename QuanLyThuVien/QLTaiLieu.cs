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
using QuanLyThuVien.Model;
using System.Data.Entity.Migrations;

namespace QuanLyThuVien
{
    public partial class QLTaiLieu : Form
    {
        public QLTaiLieu()
        {
            InitializeComponent();
        }
        DbContentQLThuVien dbContent = new DbContentQLThuVien();
        Boolean flag;
        string chuoiketnoi = @"Data Source=COMBO\TANLOC;Initial Catalog=QuanLyThuVien1;Integrated Security=True";
        SqlConnection ketnoi;
        private void setControls(bool val)
        {
            txtMaTL.Enabled = !val;
            txtTenTL.Enabled = !val;
            txtTheLoai.Enabled = !val;
            txtTacGia.Enabled = !val;
            txtNXB.Enabled = !val;
            txtNamXB.Enabled = !val;
            txtSLNhap.Enabled = !val;
            txtDonGia.Enabled = !val;
            cbbTinhTrang.Enabled = !val;
        }
        public void SetButton(bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
            btnThoat.Enabled = val;
        }
        private void QLTaiLieu_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            List<TaiLieu> listTaiLieu = dbContent.TaiLieu.ToList();
            FillDataDGV(listTaiLieu);
            cbbTinhTrang.SelectedIndex = 0;
            txtMaTL.Focus();
            loadDGV();
            loadForm();
            SetButton(true);
            setControls(true);

        }
        private void loadDGV()              //Load data
        {
            List<TaiLieu> newTaiLieu = dbContent.TaiLieu.ToList();
            FillDataDGV(newTaiLieu);
        }
        private void loadForm()
        {
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtTheLoai.Clear();
            txtTacGia.Clear();
            txtNXB.Clear();
            txtNamXB.Clear();
            txtSLNhap.Clear();
            txtDonGia.Clear();
            cbbTinhTrang.SelectedIndex = 0;
        }
        private void FillDataDGV(List<TaiLieu> listTaiLieu)           //Load data vao dgv
        {
            dgvTaiLieu.Rows.Clear();
            foreach (var item in listTaiLieu)
            {
                int newRow = dgvTaiLieu.Rows.Add();
                dgvTaiLieu.Rows[newRow].Cells[0].Value = item.MaSach;
                dgvTaiLieu.Rows[newRow].Cells[1].Value = item.TenSach;
                dgvTaiLieu.Rows[newRow].Cells[2].Value = item.TheLoai;
                dgvTaiLieu.Rows[newRow].Cells[3].Value = item.TacGia;
                dgvTaiLieu.Rows[newRow].Cells[4].Value = item.NXB;
                dgvTaiLieu.Rows[newRow].Cells[5].Value = item.NamXB;
                dgvTaiLieu.Rows[newRow].Cells[6].Value = item.SLNhap;
                dgvTaiLieu.Rows[newRow].Cells[7].Value = item.DonGia;
                dgvTaiLieu.Rows[newRow].Cells[8].Value = item.TinhTrang;
            }
        }
        private int CheckMaTaiLieu(string MaTaiLieu)
        {
            for (int i = 0; i < dgvTaiLieu.Rows.Count; i++)
            {
                if (dgvTaiLieu.Rows[i].Cells[0].Value != null)
                {
                    if (dgvTaiLieu.Rows[i].Cells[0].Value.ToString() == MaTaiLieu)
                    {
                        return i;
                    }
                }
            }
            return -1;  //-1 khi khong tim thay doc gia co ma so moi
        }
        private bool CheckDataInput()           // kiem tra du lieu dau vao
        {
            if (txtMaTL.Text == "" || txtTenTL.Text == "" || txtTheLoai.Text == "" | txtTacGia.Text == "" ||
                txtNXB.Text == "" || txtSLNhap.Text == "" || txtDonGia.Text == "" || cbbTinhTrang.Text == "")
            {
                setControls(true);
                MessageBox.Show("Thiếu dữ liệu ! Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtMaTL.TextLength > 5)
            {
                MessageBox.Show("Mã tài liệu phải tối đa 5 ký tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;        // neu khong co IF nao dung (k co loi)
        }

        private void dgvTaiLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTaiLieu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvTaiLieu.CurrentRow.Selected = true;
                    txtMaTL.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenTL.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtTheLoai.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtTacGia.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    txtNXB.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    txtNamXB.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    txtSLNhap.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    txtDonGia.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    cbbTinhTrang.Text = dgvTaiLieu.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            loadForm();
            txtMaTL.Focus();
            flag = true;
            setControls(false);
            SetButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckDataInput() == true)
            {
                setControls(false);
                flag = false;
                txtMaTL.Enabled = false;
                SetButton(false);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài liệu để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setControls(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckDataInput() == true)
            {
                TaiLieu XoaTL = dbContent.TaiLieu.Where(p => p.MaSach == txtMaTL.Text).FirstOrDefault();
                if (XoaTL != null)        // neu tra ve -1 thi nhan vien chua co trong danh sach
                {
                    DialogResult XD = MessageBox.Show("Bạn có muốn xóa tài liệu này không ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (XD == DialogResult.Yes)
                    {

                        dbContent.TaiLieu.Remove(XoaTL);
                        dbContent.SaveChanges();

                        loadForm();
                        loadDGV();

                        MessageBox.Show($"Xóa tài liệu {XoaTL.MaSach} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"Xóa tài liệu {txtMaTL.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài liệu để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTL.Text == "")
            {
                errMaTL.SetError(txtMaTL, "Vui lòng nhập mã tài liệu !");
            }
            else
            {
                errMaTL.Clear();
            }

            if (txtTenTL.Text == "")
            {
                errTenTL.SetError(txtTenTL, "Vui lòng nhập tên tài liệu !");
            }
            else
            {
                errTenTL.Clear();
            }
            if (txtTheLoai.Text == "")
            {
                errTheLoai.SetError(txtTheLoai, "Vui lòng nhập thể loại !");
            }
            else
            {
                errTheLoai.Clear();
            }

            if (txtTacGia.Text == "")
            {
                errTacGia.SetError(txtTacGia, "Vui lòng nhập tên tác giả !");
            }
            else
            {
                errTacGia.Clear();
            }
            if (txtNXB.Text == "")
            {
                errNXB.SetError(txtNXB, "Vui lòng nhập nhà xuất bản !");
            }
            else
            {
                errNXB.Clear();
            }

            if (txtNamXB.Text == "")
            {
                errNamXB.SetError(txtNamXB, "Vui lòng nhập năm xuất bản !");
            }
            else
            {
                errNamXB.Clear();
            }
            if (txtSLNhap.Text == "")
            {
                errSLNhap.SetError(txtSLNhap, "Vui lòng nhập số lượng !");
            }
            else
            {
                errSLNhap.Clear();
            }

            if (txtDonGia.Text == "")
            {
                errDonGia.SetError(txtDonGia, "Vui lòng nhập đơn giá !");
            }
            else
            {
                errDonGia.Clear();
            }
            if (flag == true)
            {
                if (CheckDataInput() == true)
                {
                    if (CheckMaTaiLieu(txtMaTL.Text) == -1)        // neu tra ve -1 thi sv chua co trong ds
                    {
                        TaiLieu newTaiLieu = new TaiLieu();        // khoi tao nhan vien moi
                        newTaiLieu.MaSach = txtMaTL.Text;
                        newTaiLieu.TenSach = txtTenTL.Text;
                        newTaiLieu.TheLoai = txtTheLoai.Text;
                        newTaiLieu.TacGia = txtTacGia.Text;
                        newTaiLieu.NXB = txtNXB.Text;
                        newTaiLieu.NamXB = Convert.ToInt32(txtNamXB.Text);
                        newTaiLieu.SLNhap = Convert.ToInt32(txtSLNhap.Text);
                        newTaiLieu.DonGia = Convert.ToInt32(txtDonGia.Text);
                        newTaiLieu.TinhTrang = cbbTinhTrang.Text;
                        //dua data xuong db va luu
                        dbContent.TaiLieu.AddOrUpdate(newTaiLieu);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Thêm tài liệu {txtMaTL.Text} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                        SetButton(true);
                    }
                    else
                    {
                        MessageBox.Show($"Thêm tài liệu {txtMaTL.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (CheckDataInput() == true)
                {
                    // lay sv dua vao ma so sv
                    TaiLieu updateTL = dbContent.TaiLieu.Where(p => p.MaSach == txtMaTL.Text).FirstOrDefault();

                    if (updateTL != null)        // neu tra ve -1 thi sv chua co trong ds
                    {      // khoi tao nhan vien moi
                        updateTL.MaSach = txtMaTL.Text;
                        updateTL.TenSach = txtTenTL.Text;
                        updateTL.TheLoai = txtTheLoai.Text;
                        updateTL.TacGia = txtTacGia.Text;
                        updateTL.NXB = txtNXB.Text;
                        updateTL.NamXB = Convert.ToInt32(txtNamXB.Text);
                        updateTL.SLNhap = Convert.ToInt32(txtSLNhap.Text);
                        updateTL.DonGia = Convert.ToInt32(txtDonGia.Text);
                        updateTL.TinhTrang = cbbTinhTrang.Text;
                        //dua data xuong db va luu
                        dbContent.TaiLieu.AddOrUpdate(updateTL);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Sửa tài liệu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                        SetButton(true);
                    }
                    else
                    {
                        MessageBox.Show($"Sửa tài liệu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControls(true);
            SetButton(true);
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

        private void txtTheLoai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
