using Shop_Luitsvuituoi.GUI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Shop_Luitsvuituoi
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
        private void Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(960, 540);
            //string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = $"SELECT * FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableNhanVien.DataSource = dtbl;
        }

        private void btnListKhachHang_Click(object sender, EventArgs e)
        {
            using (KhachHang formKH = new KhachHang())
            {
                if (formKH.ShowDialog() == DialogResult.OK)
                {
                    txtMaKhachHang.Text = formKH.Ma_KH;
                    txtTenKhachHang.Text = formKH.Ten_KH;
                    txtPhone.Text = formKH.Phone_KH;
                }
            }
        }

        private void btnTaoKH_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connectionString);
            string tenKH = txtTenKhachHang.Text;
            string phone = txtPhone.Text;
            string query = $"INSERT INTO khachhang (tenKhachHang,phone) VALUES ('{tenKH}','{phone}')";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            using (AllSanPham formSP = new AllSanPham())
            {
                if (formSP.ShowDialog() == DialogResult.OK)
                {
                    comboboxMaSP.Text = formSP.MaHH;
                    txtGiaTien.Text = formSP.DonGiaHH;
                    txtLoaiSP.Text = formSP.LoaiHH;
                    txtTenSP.Text = formSP.TenHH;
                }
            }
        }


        private void tableNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tableNhanVien.CurrentRow.Selected = true;
            txtMaNV.Text = tableNhanVien.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtUsername.Text = tableNhanVien.Rows[e.RowIndex].Cells["username"].Value.ToString();
            txtPass.Text = tableNhanVien.Rows[e.RowIndex].Cells["password"].Value.ToString();
            txtEmail.Text = tableNhanVien.Rows[e.RowIndex].Cells["email"].Value.ToString();
            txtTenNV.Text = tableNhanVien.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
            txtBirth.Text = tableNhanVien.Rows[e.RowIndex].Cells["birth"].Value.ToString();
            txtAddress.Text = tableNhanVien.Rows[e.RowIndex].Cells["address"].Value.ToString();
            txtPhoneNV.Text = tableNhanVien.Rows[e.RowIndex].Cells["phone"].Value.ToString();
            //txtMaHH.Text = tableHangHoa.Rows[e.RowIndex].Cells["id_hh"].Value.ToString();

        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string queryNV = $"INSERT INTO nhanvien (username,password,email,full_name,birth,address,phone) VALUES ('{txtUsername.Text}','{txtPass.Text}','{txtEmail.Text}','{txtTenNV.Text}','{txtBirth.Text}','{txtAddress.Text}','{txtPhoneNV.Text}')";
            SqlCommand cmd = new SqlCommand(queryNV, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
                string query = $"SELECT * FROM nhanvien";
                SqlDataAdapter da = new SqlDataAdapter(query, cnn);
                DataTable dtbl = new DataTable();
                da.Fill(dtbl);
                tableNhanVien.DataSource = dtbl;
            cnn.Close();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = $"SELECT * FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableNhanVien.DataSource = dtbl;
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            //string queryNV = $"INSERT INTO nhanvien (username,password,email,full_name,birth,address,phone) VALUES ('{txtUsername.Text}','{txtPass.Text}','{txtEmail.Text}','{txtTenNV.Text}','{txtBirth.Text}','{txtAddress.Text}','{txtPhoneNV.Text}')";
            string queryNV = $"UPDATE nhanvien SET username = '{txtUsername.Text}', password = '{txtPass.Text}', email = '{txtEmail.Text}', full_name = '{txtTenNV.Text}', address = '{txtAddress.Text}', phone = '{txtPhone.Text}' WHERE id = '{txtMaNV.Text}'";
            SqlCommand cmd = new SqlCommand(queryNV, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            //
            string query = $"SELECT * FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableNhanVien.DataSource = dtbl;
            //
            cnn.Close();
            MessageBox.Show("Sửa thành công du lieu cho!" + txtTenNV.Text);
        }
    }
}
