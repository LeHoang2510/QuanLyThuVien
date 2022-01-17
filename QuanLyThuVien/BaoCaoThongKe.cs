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
    public partial class BaoCaoThongKe : Form
    {
        public BaoCaoThongKe()
        {
            InitializeComponent();
        }
        string strKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlCommand myCommand;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;

        private SqlDataReader myDataReaderSLDauSach;
        private SqlDataReader myDataReaderSLMuon;
        private SqlDataReader myDataReaderSLDG;
        private SqlDataReader myDataReaderSLDGMuon;
        private SqlDataReader myDataReaderSLSQuaHan;
        private SqlDataReader myDataReaderSLDGQuaHan;
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dgvBCTK.DataSource = myTable;
            return myTable;
        }
        public string luuSLDauSach, luuSLCuon, luuTongGiaTriSach;
        private void slDauSach()
        {
            string strTinhSLDauSach = "select count(MaSach) as TongSLDauSach, sum(SLNhap) as TongSLSach, sum(DonGia) as TongGiaTriSach from TaiLieu";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(strTinhSLDauSach, myConnection);
            myDataReaderSLDauSach = myCommand.ExecuteReader();
            while (myDataReaderSLDauSach.Read())
            {
                luuSLDauSach = myDataReaderSLDauSach.GetInt32(0).ToString();
                luuSLCuon = myDataReaderSLDauSach.GetInt32(1).ToString();
                luuTongGiaTriSach = myDataReaderSLDauSach.GetInt32(2).ToString();
            }
        }
        public string luuSLMuon;
        private void slMuon()
        {
            string strTinhSLMuon = "select sum(SLMuon) as Tong from PhieuMuonTra";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(strTinhSLMuon, myConnection);
            myDataReaderSLMuon = myCommand.ExecuteReader();
            while (myDataReaderSLMuon.Read())
            {
                luuSLMuon = myDataReaderSLMuon.GetInt32(0).ToString();
            }
        }
        public string luuSLDG;
        private void slDocGia()
        {
            string strTinhSLMuon = "select count(MaDG) as TongSLDG from DocGia";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(strTinhSLMuon, myConnection);
            myDataReaderSLDG = myCommand.ExecuteReader();
            while (myDataReaderSLDG.Read())
            {
                luuSLDG = myDataReaderSLDG.GetInt32(0).ToString();
            }
        }
        public string luuSLDGMuon;
        private void slDocGiaMuon()
        {
            string strTinhSLMuon = "select (count(distinct(MaDG))) as TongSLDGMuon from PhieuMuonTra";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(strTinhSLMuon, myConnection);
            myDataReaderSLDGMuon = myCommand.ExecuteReader();
            while (myDataReaderSLDGMuon.Read())
            {
                luuSLDGMuon = myDataReaderSLDGMuon.GetInt32(0).ToString();
            }
        }
        public string luuSLSQuaHan;
        private void slSachQuaHan()
        {
            string strTinhSLSachQuaHan = "SELECT count(SLMuon) as TongSLQuaHan from PhieuMuonTra where  NgayTra < getdate()";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(strTinhSLSachQuaHan, myConnection);
            myDataReaderSLSQuaHan = myCommand.ExecuteReader();
            while (myDataReaderSLSQuaHan.Read())
            {
                luuSLSQuaHan = myDataReaderSLSQuaHan.GetInt32(0).ToString();
            }
        }
        public string luuSLDGQuaHan;

        private void btnTLQH_Click(object sender, EventArgs e)
        {
            string strTimSLSQuaHan = @"SELECT MaPhieu as 'Mã Phiếu', MaDG as 'Mã DG', MaSach as 'Mã Sách', NgayMuon as 'Ngày Mượn', NgayTra as 'Ngày Trả' from PhieuMuonTra where  NgayTra < getdate()";
            dgvBCTK.DataSource = ketnoi(strTimSLSQuaHan);
            dgvBCTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBCTK.Show();

        }

        private void btnDGQH_Click(object sender, EventArgs e)
        {
            string strTimSLDGQuaHan = @"SELECT MaDG as 'Mã DG', count(SLMuon) as 'SL Sách Mượn' from PhieuMuonTra where  NgayTra <= getdate() group by MaDG";
            dgvBCTK.DataSource = ketnoi(strTimSLDGQuaHan);
            dgvBCTK.Columns["SL Sách Mượn"].Width = 440;
            dgvBCTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBCTK.Show();
        }

        private void BaoCaoThongKe_Click(object sender, EventArgs e)
        {
            dgvBCTK.Hide();
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

        private void slDGQuaHan()
        {
            string strTinhSLDGQuaHan = "SELECT count(distinct(MaDG)) as TongSLQuaHan from PhieuMuonTra where  NgayTra < getdate()";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(strTinhSLDGQuaHan, myConnection);
            myDataReaderSLDGQuaHan = myCommand.ExecuteReader();
            while (myDataReaderSLDGQuaHan.Read())
            {
                luuSLDGQuaHan = myDataReaderSLDGQuaHan.GetInt32(0).ToString();
            }
        }

        private void BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            txtDauSach.Enabled = false;
            txtSLCUON.Enabled = false;
            txtSLCON.Enabled = false;
            txtSLMUON.Enabled = false;
            txtTONGGT.Enabled = false;
            txtSLSACHQH.Enabled = false;

            txtDGQH.Enabled = false;
            txtSLDG.Enabled = false;
            txtDGMUON.Enabled = false;

            dgvBCTK.Hide();

            // Tổng SL Đầu sách, sl nhập, sl còn , tổng giá trị
            slDauSach();
            txtDauSach.Text = luuSLDauSach;
            txtSLCUON.Text = luuSLCuon;
            txtTONGGT.Text = luuTongGiaTriSach;

            // tổng sl mượn
            slMuon();
            txtDGMUON.Text = luuSLMuon;
            int luuSLCon = Convert.ToInt32(luuSLCuon) - Convert.ToInt32(luuSLMuon);
            txtSLCON.Text = luuSLCon.ToString();

            // tổng sl độc giả
            slDocGia();
            txtSLDG.Text = luuSLDG;

            // SL  độc giả đã mượn sahcs
            slDocGiaMuon();
            txtDGMUON.Text = luuSLDGMuon;


            // SL Sách quá hạn
            slSachQuaHan();
            txtSLSACHQH.Text = luuSLSQuaHan;

            //SL DG quá hạn
            slDGQuaHan();
            txtDGQH.Text = luuSLDGQuaHan;
        }
    }
}
