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
    public partial class TimKiemNhanVien : Form
    {
        public TimKiemNhanVien()
        {
            InitializeComponent();
        }
        string chuoiKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;
        private SqlCommand myCommand;
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            dgvTimKiem.DataSource = myTable;
            return myTable;
        }
        private void TimKiemNhanVien_Load(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from NhanVien";
            dgvTimKiem.DataSource = ketnoi(cauTruyVan);
            dgvTimKiem.AutoGenerateColumns = false;
            myConnection.Close();
            dgvTimKiem.Enabled = true;
        }
        private void txtTimKiemDG_TextChanged(object sender, EventArgs e)
        {
            if (rdbMaNV.Checked)
            {
                string timkiemMS = "select * from DocGia where MaDG like '%" + txtTimKiemNV.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dgvTimKiem.DataSource = myTable;
                dgvTimKiem.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (rdbTenNV.Checked)
            {
                string timkiemTS = "select * from DocGia where TenDG like N'%" + txtTimKiemNV.Text + "%'";
                ketnoi(timkiemTS);
                myCommand.ExecuteNonQuery();
                dgvTimKiem.DataSource = ketnoi(timkiemTS);
                dgvTimKiem.AutoGenerateColumns = false;
                myConnection.Close();
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
