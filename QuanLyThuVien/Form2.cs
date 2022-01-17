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

        string chuoiketnoi = @"Data Source=COMBO\TANLOC;Initial Catalog=QuanLyThuVien;Integrated Security=True";
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
        private int CheckMaDocGia(string MaDoGia)
        {
            for (int i = 0; i < dgvDocGia.Rows.Count; i++)
            {
                if (dgvDocGia.Rows[i].Cells[0].Value != null)
                {
                    if (dgvDocGia.Rows[i].Cells[0].Value.ToString() == MaDoGia)
                    {
                        return i;
                    }
                }
            }
            return -1;  //-1 khi khong tim thay doc gia co ma so moi
        }
        private bool CheckDataInput()           // kiem tra du lieu dau vao
        {
            if (txtMaDG.Text == "" || txtTenDG.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || cbbGioiTinh.Text == "")
            {
                setControls(true);
                MessageBox.Show("Thiếu dữ liệu ! Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtMaDG.TextLength > 5)
            {
                MessageBox.Show("Mã số độc giả phải tối đa 5 ký tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Bạn chưa chọn độc giả để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setControls(true);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text == "")
            {
                errMaDG.SetError(txtMaDG, "Vui lòng nhập mã độc giả !");
            }
            else
            {
                errMaDG.Clear();
            }

            if (txtTenDG.Text == "")
            {
                errTenDG.SetError(txtTenDG, "Vui lòng nhập tên độc giả !");
            }
            else
            {
                errTenDG.Clear();
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
            if (flag == true)
            {
                if (CheckDataInput() == true)
                {
                    if (CheckMaDocGia(txtMaDG.Text) == -1)        // neu tra ve -1 thi doc gia chua co trong ds
                    {
                        DocGia newDocGia = new DocGia();        // khoi tao doc gia moi
                        newDocGia.MaDG = txtMaDG.Text;
                        newDocGia.TenDG = txtTenDG.Text;
                        newDocGia.GioiTinh = cbbGioiTinh.Text;
                        newDocGia.NgaySinh = dtmNgaySinh.Value;
                        newDocGia.SDT = Convert.ToInt32(txtSDT.Text);
                        newDocGia.DiaChi = txtDiaChi.Text;
                        //dua data xuong db va luu
                        dbContent.DocGia.AddOrUpdate(newDocGia);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Thêm độc giả {txtMaDG.Text} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                        SetButton(true);
                    }
                    else
                    {
                        MessageBox.Show($"Thêm độc giả {txtMaDG.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (CheckDataInput() == true)
                {
                    DocGia updateDG = dbContent.DocGia.Where(p => p.MaDG == txtMaDG.Text).FirstOrDefault();

                    if (updateDG != null)        // neu tra ve -1 thi doc gia chua co trong ds
                    {
                        updateDG.MaDG = txtMaDG.Text;
                        updateDG.TenDG = txtTenDG.Text;
                        updateDG.GioiTinh = cbbGioiTinh.Text;
                        updateDG.NgaySinh = dtmNgaySinh.Value;
                        updateDG.SDT = Convert.ToInt32(txtSDT.Text);
                        updateDG.DiaChi = txtDiaChi.Text;
                        dbContent.DocGia.AddOrUpdate(updateDG);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Sửa độc giả {updateDG.MaDG} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                        SetButton(true);
                    }
                    else
                    {
                        MessageBox.Show($"Sửa độc giả {txtMaDG} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckDataInput() == true)
            {
                DocGia XoaDG = dbContent.DocGia.Where(p => p.MaDG == txtMaDG.Text).FirstOrDefault();
                if (XoaDG != null)        // neu tra ve -1 thi doc gia chua co trong ds
                {
                    DialogResult XD = MessageBox.Show("Bạn có muốn xóa độc giả này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (XD == DialogResult.Yes)
                    {
                        dbContent.DocGia.Remove(XoaDG);
                        dbContent.SaveChanges();
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Xóa độc giả {XoaDG.MaDG} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
                else
                {
                    MessageBox.Show($"Xóa độc giả {txtMaDG.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn độc giả để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
