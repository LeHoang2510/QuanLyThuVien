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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DbContentQLThuVien dbContent = new DbContentQLThuVien();
        Boolean flag;

        string chuoiketnoi = @"Data Source=COMBO\TANLOC;Initial Catalog=QuanLyThuVien1;Integrated Security=True";
        SqlConnection ketnoi;
        private void setControls(bool val)
        {
            txtMaDG.Enabled = !val;
            txtTenDG.Enabled = !val;
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
        private void Form2_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            List<DocGia> listDocGia = dbContent.DocGia.ToList();
            FillDataDGV(listDocGia);
            cbbGioiTinh.SelectedIndex = 0;
            txtMaDG.Focus();
            loadDGV();
            loadForm();
            SetButton(true);
            setControls(true);
        }
        private void loadDGV()              //load data
        {
            List<DocGia> listDocGia = dbContent.DocGia.ToList();
            FillDataDGV(listDocGia);
        }
        private void loadForm()
        {
            txtMaDG.Clear();
            txtTenDG.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtmNgaySinh.Value = DateTime.Now;
            cbbGioiTinh.SelectedIndex = 0;
        }
        private void FillDataDGV(List<DocGia> listDocGia)           //load data vao dgv
        {
            dgvDocGia.Rows.Clear();
            foreach (var item in listDocGia)
            {
                int newRow = dgvDocGia.Rows.Add();
                dgvDocGia.Rows[newRow].Cells[0].Value = item.MaDG;
                dgvDocGia.Rows[newRow].Cells[1].Value = item.TenDG;
                dgvDocGia.Rows[newRow].Cells[2].Value = item.GioiTinh;
                dgvDocGia.Rows[newRow].Cells[3].Value = item.NgaySinh;
                dgvDocGia.Rows[newRow].Cells[4].Value = item.SDT;
                dgvDocGia.Rows[newRow].Cells[5].Value = item.DiaChi;
            }
        }
        private int CheckIDDocGia(string idDoGia)
        {
            for (int i = 0; i < dgvDocGia.Rows.Count; i++)
            {
                if (dgvDocGia.Rows[i].Cells[0].Value != null)
                {
                    if (dgvDocGia.Rows[i].Cells[0].Value.ToString() == idDoGia)
                    {
                        return i;
                    }
                }
            }
            return -1;  //-1 khi khong tim thay sinh vien co ma so moi
        }
        private bool CheckDataInput()           // kiem tra du lieu dau vao
        {
            if (txtMaDG.Text == "" || txtTenDG.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || cbbGioiTinh.Text == "")
            {
                MessageBox.Show("Thiếu dữ liệu ! Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;        // neu khong co IF nao dung (k co loi)
        }

        private void dgvDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDocGia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvDocGia.CurrentRow.Selected = true;
                    txtMaDG.Text = dgvDocGia.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenDG.Text = dgvDocGia.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    cbbGioiTinh.Text = dgvDocGia.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    dtmNgaySinh.Text = dgvDocGia.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    txtSDT.Text = dgvDocGia.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    txtDiaChi.Text = dgvDocGia.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            loadForm();
            txtMaDG.Focus();
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
                txtMaDG.Enabled = false;
                SetButton(false);
            }
            else
            {
                setControls(true);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (CheckDataInput() == true)
                {
                    if (CheckIDDocGia(txtMaDG.Text) == -1)        // neu tra ve -1 thi sv chua co trong ds
                    {
                        DocGia newDocGia = new DocGia();        // khoi tao sv moi
                        newDocGia.MaDG = txtMaDG.Text;
                        newDocGia.TenDG = txtTenDG.Text;
                        newDocGia.GioiTinh = cbbGioiTinh.Text;
                        newDocGia.NgaySinh = dtmNgaySinh.Text;
                        newDocGia.SDT = Convert.ToInt32(txtSDT.Text);
                        newDocGia.DiaChi = txtDiaChi.Text;
                        //dua data xuong db va luu
                        dbContent.DocGia.AddOrUpdate(newDocGia);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Thêm Nhân viên {txtMaDG.Text} thành công!", "Thông báo");
                        setControls(true);
                    }
                    else
                    {
                        MessageBox.Show($"Thêm Nhân viên {txtMaDG.Text} thất bại", "Thông báo");
                    }
                }
            }
            else
            {
                if (CheckDataInput() == true)
                {
                    // lay sv dua vao ma so sv
                    DocGia updateDG = dbContent.DocGia.Where(p => p.MaDG == txtMaDG.Text).FirstOrDefault();

                    if (updateDG != null)        // neu tra ve -1 thi sv chua co trong ds
                    {
                        updateDG.MaDG = txtMaDG.Text;
                        updateDG.TenDG = txtTenDG.Text;
                        updateDG.GioiTinh = cbbGioiTinh.Text;
                        updateDG.NgaySinh = dtmNgaySinh.Text;
                        updateDG.SDT = Convert.ToInt32(txtSDT.Text);
                        updateDG.DiaChi = txtDiaChi.Text;

                        dbContent.DocGia.AddOrUpdate(updateDG);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();

                        MessageBox.Show($"Sửa sinh viên {updateDG.MaDG} thành công!", "Thông báo");
                        setControls(true);
                    }
                    else
                    {
                        MessageBox.Show($"Sửa sinh viên {txtMaDG} thất bại", "Thông báo");
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
            DialogResult rtx = MessageBox.Show("Bạn có muốn thoát ?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rtx == DialogResult.Yes)
            {
                this.Hide();
                //GiaoDien Thoat = new GiaoDien();
                this.Closed += (s, args) => this.Close();
                this.Show();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DocGia XoaDG = dbContent.DocGia.Where(p => p.MaDG == txtMaDG.Text).FirstOrDefault();
            if (XoaDG != null)        // neu tra ve -1 thi sv chua co trong ds
            {
                DialogResult XD = MessageBox.Show("Bạn có chắc muốn xóa sinh viên ? ", "Yes/No", MessageBoxButtons.YesNo);
                if (XD == DialogResult.Yes)
                {

                    dbContent.DocGia.Remove(XoaDG);
                    dbContent.SaveChanges();

                    loadForm();
                    loadDGV();

                    MessageBox.Show($"Xóa Nhân viên {XoaDG.MaDG} thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show($"Xóa Nhân viên {txtMaDG.Text} thất bại", "Thông báo");
                }
            }
        }
    }
}
