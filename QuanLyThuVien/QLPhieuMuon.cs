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
    public partial class QLPhieuMuon : Form
    {
        public QLPhieuMuon()
        {
            InitializeComponent();
        }
        DbContentQLThuVien dbContent = new DbContentQLThuVien();
        Boolean flag;
        string chuoiketnoi = @"Data Source=COMBO\TANLOC;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        SqlConnection ketnoi;
        private void setControls(bool val)
        {
            txtMaPhieu.Enabled = !val;
            txtMaPhieu1.Enabled = !val;
            txtMaDG.Enabled = !val;
            txtMaDG1.Enabled = !val;
            txtMaTL.Enabled = !val;
            txtMaTL1.Enabled = !val;
            dtmNgayMuon.Enabled = !val;
            dtmNgayMuon1.Enabled = !val;
            dtmNgayTra.Enabled = !val;
            dtmNgayTra1.Enabled = !val;
            txtSLMuon.Enabled = !val;
            txtSLMuon1.Enabled = !val;
            cbbTinhTrang.Enabled = !val;
            cbbTinhTrang1.Enabled = !val;
        }
        public void SetButton(bool val)
        {
            btnMuonMoi.Enabled = val;
            btnLuu.Enabled = !val;
            btnGiaHan.Enabled = val;
            btnHuy.Enabled = !val;
            btnThoat.Enabled = val;
            btnThoat1.Enabled = val;
        }
        private void FillDataDGV(List<PhieuMuonTra> listPhieuMuonTra)           //load data vao dgv
        {
            dgvMuon.Rows.Clear();
            dgvTra.Rows.Clear();
            foreach (var item in listPhieuMuonTra)
            {
                int newRow = dgvMuon.Rows.Add();
                int Row = dgvTra.Rows.Add();
                dgvMuon.Rows[newRow].Cells[0].Value = item.MaPhieu;
                dgvMuon.Rows[newRow].Cells[1].Value = item.MaDG;
                dgvMuon.Rows[newRow].Cells[2].Value = item.MaTL;
                dgvMuon.Rows[newRow].Cells[3].Value = item.NgayMuon;
                dgvMuon.Rows[newRow].Cells[4].Value = item.NgayTra;
                dgvMuon.Rows[newRow].Cells[5].Value = item.SLMuon;
                dgvMuon.Rows[newRow].Cells[6].Value = item.TinhTrang;
                dgvTra.Rows[newRow].Cells[0].Value = item.MaPhieu;
                dgvTra.Rows[newRow].Cells[1].Value = item.MaDG;
                dgvTra.Rows[newRow].Cells[2].Value = item.MaTL;
                dgvTra.Rows[newRow].Cells[3].Value = item.NgayMuon;
                dgvTra.Rows[newRow].Cells[4].Value = item.NgayTra;
                dgvTra.Rows[newRow].Cells[5].Value = item.SLMuon;
                dgvTra.Rows[newRow].Cells[6].Value = item.TinhTrang;
            }
        }

        private void QLPhieuMuon_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            List<PhieuMuonTra> listPhieuMuonTra = dbContent.PhieuMuonTra.ToList();
            FillDataDGV(listPhieuMuonTra);
            setControls(true);
            SetButton(true);
            cbbTinhTrang.SelectedIndex = 0;
            cbbTinhTrang1.SelectedIndex = 0;
            loadDGV();
            loadForm();
        }
        private void loadForm()
        {
            txtMaPhieu.Clear();
            txtMaDG.Clear();
            txtMaTL.Clear();
            dtmNgayMuon.Value = DateTime.Now;
            dtmNgayTra.Value = DateTime.Now;
            cbbTinhTrang.SelectedIndex = 0;
            txtMaPhieu1.Clear();
            txtMaDG1.Clear();
            txtMaTL1.Clear();
            dtmNgayMuon1.Value = DateTime.Now;
            dtmNgayTra1.Value = DateTime.Now;
            cbbTinhTrang1.SelectedIndex = 0;
        }
        private int CheckIDPhieuMuon(string idPhieuMuon)
        {
            for (int i = 0; i < dgvMuon.Rows.Count; i++)
            {
                if (dgvMuon.Rows[i].Cells[0].Value != null)
                {
                    if (dgvMuon.Rows[i].Cells[0].Value.ToString() == idPhieuMuon)
                    {
                        return -1;
                    }
                }
            }
            return -1;  //-1 khi khong tim thay sinh vien co ma so moi
        }
        private bool CheckDataInput0()           // kiem tra du lieu dau vao
        {
            if (txtMaPhieu.Text == "" || txtMaDG.Text == "" || txtMaTL.Text == "" || txtSLMuon.Text == "" || cbbTinhTrang.Text == "")
            {
                MessageBox.Show("Thiếu dữ liệu ! Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                int SL = 0;
                bool SoLuong = int.TryParse(txtSLMuon.Text, out SL);
                if (SoLuong != true)
                {
                    MessageBox.Show("Dữ liệu số lượng mượn phải là số !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtMaPhieu.TextLength > 5)
                {
                    MessageBox.Show("Mã phiếu mượn không quá 5 ký tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtMaDG.TextLength > 5)
                {
                    MessageBox.Show("Mã độc giả không quá 5 ký tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtMaTL.TextLength > 5)
                {
                    MessageBox.Show("Mã tài liệu không quá 5 ký tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;        // neu khong co IF nao dung (k co loi)           
        }

        private void loadDGV()              //load data
        {
            List<PhieuMuonTra> listPhieuMuonTra = dbContent.PhieuMuonTra.ToList();
            FillDataDGV(listPhieuMuonTra);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rtx = MessageBox.Show("Bạn có muốn thoát ?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rtx == DialogResult.Yes)
            {
                this.Hide();
                GiaoDien Thoat = new GiaoDien();
                Thoat.Closed += (s, args) => this.Close();
                Thoat.Show();
            }
        }

        private void dgvMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMuon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvMuon.CurrentRow.Selected = true;
                    txtMaPhieu.Text = dgvMuon.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtMaDG.Text = dgvMuon.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtMaTL.Text = dgvMuon.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    dtmNgayMuon.Text = dgvMuon.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    dtmNgayTra.Text = dgvMuon.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    txtSLMuon.Text = dgvMuon.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    cbbTinhTrang.Text = dgvMuon.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }

        }

        private void dgvTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTra.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvTra.CurrentRow.Selected = true;
                    txtMaPhieu1.Text = dgvTra.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtMaDG1.Text = dgvTra.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtMaTL1.Text = dgvTra.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    dtmNgayMuon1.Text = dgvTra.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    dtmNgayTra1.Text = dgvTra.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    txtSLMuon1.Text = dgvTra.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    cbbTinhTrang1.Text = dgvTra.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }

        }

        private void btnMuonMoi_Click(object sender, EventArgs e)
        {
            loadForm();
            txtMaPhieu.Focus();
            flag = true;
            setControls(false);
            SetButton(false);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (CheckDataInput0() == true)
                {
                    if (CheckIDPhieuMuon(txtMaPhieu.Text) == -1)        // neu tra ve -1 thi sv chua co trong ds
                    {
                        PhieuMuonTra newPhieuMuon = new PhieuMuonTra();
                        newPhieuMuon.MaPhieu = txtMaPhieu.Text;
                        newPhieuMuon.MaDG = txtMaDG.Text;
                        newPhieuMuon.MaTL = txtMaTL.Text;
                        newPhieuMuon.NgayMuon = dtmNgayMuon.Value;
                        newPhieuMuon.NgayTra = dtmNgayTra.Value;
                        newPhieuMuon.SLMuon = Convert.ToInt32(txtSLMuon.Text);
                        newPhieuMuon.TinhTrang = cbbTinhTrang.Text;

                        dbContent.PhieuMuonTra.AddOrUpdate(newPhieuMuon);
                        dbContent.SaveChanges();
                        //reset data gird view
                        loadForm();
                        loadDGV();
                        MessageBox.Show($"Thêm thông tin {txtMaPhieu.Text} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setControls(true);
                        SetButton(true);
                    }
                    else
                    {
                        MessageBox.Show($"Thêm thông tin {txtMaPhieu.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (CheckDataInput0() == true)
                    {
                        // lay sv dua vao ma so sv
                        PhieuMuonTra updatePhieuMuon = dbContent.PhieuMuonTra.Where(p => p.MaPhieu == txtMaPhieu.Text).FirstOrDefault();

                        if (updatePhieuMuon != null)        // neu tra ve -1 thi sv chua co trong ds
                        {
                            updatePhieuMuon.MaPhieu = txtMaPhieu.Text;
                            updatePhieuMuon.MaDG = txtMaDG.Text;
                            updatePhieuMuon.MaTL = txtMaPhieu.Text;
                            updatePhieuMuon.NgayMuon = dtmNgayMuon.Value;
                            updatePhieuMuon.NgayTra = dtmNgayTra.Value;
                            updatePhieuMuon.SLMuon = Convert.ToInt32(txtSLMuon.Text);
                            updatePhieuMuon.TinhTrang = cbbTinhTrang.Text;

                            dbContent.PhieuMuonTra.AddOrUpdate(updatePhieuMuon);
                            dbContent.SaveChanges();
                            //reset data gird view
                            loadForm();
                            loadDGV();

                            MessageBox.Show($"Sửa thông tin  {updatePhieuMuon.MaDG} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setControls(true);
                        }
                        else
                        {
                            MessageBox.Show($"Sửa thông tin {txtMaPhieu} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

        }
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (CheckDataInput0() == true)
            {
                setControls(false);
                flag = false;
                txtMaPhieu.Focus();
                txtMaPhieu.Enabled = false;
                txtMaDG.Enabled = false;
                txtMaTL.Enabled = false;
                txtSLMuon.Enabled = false;
                dtmNgayMuon.Enabled = false;
                cbbTinhTrang.Enabled = false;
                SetButton(false);
            }
            else
            {
                setControls(true);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControls(true);
            SetButton(true);
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
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

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            //if(flag == true)
            //{
            //    if(CheckDataInput0 == true)
            //    {

            //    }
            //}
            PhieuMuonTra TraTL = dbContent.PhieuMuonTra.Where(p => p.MaTL == txtMaPhieu1.Text).FirstOrDefault();
            if (TraTL == null)        // neu tra ve -1 thi sv chua co trong ds
            {
                DialogResult XD = MessageBox.Show("Bạn có muốn trả tài liệu không ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (XD == DialogResult.Yes)
                {

                    dbContent.PhieuMuonTra.Remove(TraTL);
                    dbContent.SaveChanges();

                    loadForm();
                    loadDGV();

                    MessageBox.Show($"Trả tài liệu {TraTL.MaTL} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show($"Trả tài liệu {txtMaPhieu1.Text} thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat1_Click(object sender, EventArgs e)
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
