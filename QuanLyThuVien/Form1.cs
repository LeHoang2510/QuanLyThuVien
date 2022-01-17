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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbContentQLThuVien dbContent = new DbContentQLThuVien();
        Boolean flag;

        string chuoiketnoi = @"Data Source=COMBO\TANLOC;Initial Catalog=QuanLyThuVien1;Integrated Security=True";
        SqlConnection ketnoi;
        private void setControls(bool val)
        {
            txtMaNV.Enabled = !val;
            txtTenNV.Enabled = !val;
            cbbGioiTinh.Enabled = !val;
            dtmNgaySinh.Enabled = !val;
            txtSDT.Enabled = !val;
            txtDiaChi.Enabled = !val;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            List<NhanVien> listNhanVien = dbContent.NhanVien.ToList();
            FillDataDGV(listNhanVien);
            txtMaNV.Focus();
            loadDGV();
            loadForm();
            SetButton(true);
            setControls(true);
        }
        private void loadDGV()              //Load data
        {
            List<NhanVien> newNhanVien = dbContent.NhanVien.ToList();
            FillDataDGV(newNhanVien);
        }
        private void loadForm()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtmNgaySinh.Value = DateTime.Now;
            cbbGioiTinh.SelectedIndex = 0;
        }
        private void FillDataDGV(List<NhanVien> listNhanVien)           //Load data vao dgv
        {
            dgvNhanVien.Rows.Clear();
            foreach (var item in listNhanVien)
            {
                int newRow = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[newRow].Cells[0].Value = item.MaNV;
                dgvNhanVien.Rows[newRow].Cells[1].Value = item.TenNV;
                dgvNhanVien.Rows[newRow].Cells[2].Value = item.GioiTinh;
                dgvNhanVien.Rows[newRow].Cells[3].Value = item.NgaySinh;
                dgvNhanVien.Rows[newRow].Cells[4].Value = item.SDT;
                dgvNhanVien.Rows[newRow].Cells[5].Value = item.DiaChi;
            }
        }
        private int CheckMaNhanVien(string MaNhanVien)
        {
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                if (dgvNhanVien.Rows[i].Cells[0].Value != null)
                {
                    if (dgvNhanVien.Rows[i].Cells[0].Value.ToString() == MaNhanVien)
                    {
                        return i;
                    }
                }
            }
            return -1;  //-1 khi khong tim thay nhan vien co ma so moi
        }
        private bool CheckDataInput()           // kiem tra du lieu dau vao
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || cbbGioiTinh.Text == "")
            {
                setControls(true);
                MessageBox.Show("Thiếu dữ liệu ! Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtMaNV.TextLength > 5)
            {
                MessageBox.Show("Mã số nhân viên phải tối đa 5 ký tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;        // neu khong co IF nao dung (khong co loi)
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNhanVien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvNhanVien.CurrentRow.Selected = true;
                    txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    cbbGioiTinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    dtmNgaySinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            loadForm();
            txtMaNV.Focus();
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
                txtMaNV.Enabled = false;
                SetButton(false);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setControls(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckDataInput() == true)
            {
                NhanVien XoaNV = dbContent.NhanVien.Where(p => p.MaNV == txtMaNV.Text).FirstOrDefault();
                if (XoaNV != null)        // neu tra ve -1 thi nhan vien chua co trong danh sach
                {
                    DialogResult XD = MessageBox.Show("Bạn có muốn xóa nhân viên này không ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (XD == DialogResult.Yes)
                    {

                        dbContent.NhanVien.Remove(XoaNV);
                        dbContent.SaveChanges();

                        loadForm();
                        loadDGV();

                        MessageBox.Show($"Xóa nhân viên {XoaNV.MaNV} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                   
                }
                else
                {
                    MessageBox.Show($"Xóa nhân viên {txtMaNV.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                errMaNV.SetError(txtMaNV, "Vui lòng nhập mã nhân viên !");
            }
            else
            {
                errMaNV.Clear();
            }

            if (txtTenNV.Text == "")
            {
                errTenNV.SetError(txtTenNV, "Vui lòng nhập tên nhân viên !");
            }
            else
            {
                errTenNV.Clear();
            }
            if (txtSDT.Text == "")
            {
                errSDT.SetError(txtSDT, "Vui lòng nhập số điện thoại !");
            }
            else
            {
                errSDT.Clear();
            }

            if (txtDiaChi.Text == "")
            {
                errDiaChi.SetError(txtDiaChi, "Vui lòng nhập địa chỉ !");
            }
            else
            {
                errDiaChi.Clear();
            }
            //SetButton(true);
            if (flag == true)
            {
                if (CheckDataInput() == true)
                {
                    if (CheckMaNhanVien(txtMaNV.Text) == -1)        // neu tra ve -1 thi nhan vien chua co trong ds
                    {
                        NhanVien newNhanVien = new NhanVien();        // khoi tao nhan vien moi
                        newNhanVien.MaNV = txtMaNV.Text;
                        newNhanVien.TenNV = txtTenNV.Text;
                        newNhanVien.GioiTinh = cbbGioiTinh.Text;
                        newNhanVien.NgaySinh = dtmNgaySinh.Value;
                        newNhanVien.SDT = Convert.ToInt32(txtSDT.Text);
                        newNhanVien.DiaChi = txtDiaChi.Text;
                        //dua data xuong db va luu
                        dbContent.NhanVien.AddOrUpdate(newNhanVien);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Thêm nhân viên {txtMaNV.Text} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                    }
                    else
                    {
                        MessageBox.Show($"Thêm nhân viên {txtMaNV.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (CheckDataInput() == true)
                {
                    // lay nhan vien dua vao ma so nv
                    NhanVien updateNV = dbContent.NhanVien.Where(p => p.MaNV == txtMaNV.Text).FirstOrDefault();

                    if (updateNV != null)        // neu tra ve -1 thi nv chua co trong ds
                    {
                        updateNV.MaNV = txtMaNV.Text;
                        updateNV.TenNV = txtTenNV.Text;
                        updateNV.GioiTinh = cbbGioiTinh.Text;
                        updateNV.NgaySinh = dtmNgaySinh.Value;
                        updateNV.SDT = Convert.ToInt32(txtSDT.Text);
                        updateNV.DiaChi = txtDiaChi.Text;

                        dbContent.NhanVien.AddOrUpdate(updateNV);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();

                        MessageBox.Show($"Sửa nhân viên {updateNV.MaNV} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                    }
                    else
                    {
                        MessageBox.Show($"Sửa nhân viên {txtMaNV} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
