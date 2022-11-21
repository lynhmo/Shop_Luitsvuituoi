using Shop_Luitsvuituoi.GUI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

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
            //table Nhan vien
            string query = $"SELECT * FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableNhanVien.DataSource = dtbl;
            //table hang hoa
            string queryHH = $"SELECT * FROM hanghoa";
            SqlDataAdapter daHH = new SqlDataAdapter(queryHH, cnn);
            DataTable tableHH = new DataTable();
            daHH.Fill(tableHH);
            tableHangHoa.DataSource = tableHH;
            // load combobox id hang hoa
            string querycb = "select id_hh from hanghoa";
            SqlDataAdapter daHHC = new SqlDataAdapter(querycb, cnn);
            DataSet ds = new DataSet();
            daHHC.Fill(ds, "id_hh");
            comboboxMaSP.DisplayMember = "id_hh";
            comboboxMaSP.ValueMember = "id_hh";
            comboboxMaSP.DataSource = ds.Tables["id_hh"];
            //combobox loai load
            string cmbLoai = "select loai from hanghoa";
            SqlDataAdapter cmbLoai_ = new SqlDataAdapter(cmbLoai, cnn);
            DataSet ds1 = new DataSet();
            daHHC.Fill(ds1, "loai");
            comboboxLoai.DisplayMember = "loai";
            comboboxLoai.ValueMember = "loai";
            comboboxLoai.DataSource = ds.Tables["loai"];
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
            //Sử dụng toán tử 3 ngôi để kiểm tra có phải admin hay không
            boxAdmin.Checked = (Int32.Parse(tableNhanVien.Rows[e.RowIndex].Cells["admin"].Value.ToString())==1) ? true : false;
        }
        private void TextNVClear()
        {
            txtMaNV.Text = null;
            txtUsername.Text = null;
            txtPass.Text = null;
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtBirth.Text = null;
            txtAddress.Text = null;
            txtPhoneNV.Text = null;
            boxAdmin.Checked = false;
        }
        private void btnAddNV_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập username và password!!!");
            }
            else
            {
                SqlConnection cnn = new SqlConnection(connectionString);
                string queryCheck = $"SELECT count(*) FROM nhanvien WHERE username = '{txtUsername.Text}'";
                SqlCommand cmdC = new SqlCommand(queryCheck, cnn);
                cnn.Open();
                int sl = (int)cmdC.ExecuteScalar();
                if (sl >= 1)
                {
                    MessageBox.Show("Đã có người đăng ký!");
                }
                else
                {
                    int admin = (boxAdmin.Checked == true) ? 1 : 0;
                    string queryNV = $"INSERT INTO nhanvien (username,password,email,full_name,birth,address,phone,admin) VALUES ('{txtUsername.Text}','{txtPass.Text}','{txtEmail.Text}','{txtTenNV.Text}','{txtBirth.Text}','{txtAddress.Text}','{txtPhoneNV.Text}','{admin}')";
                    SqlCommand cmd = new SqlCommand(queryNV, cnn);
                    cmd.ExecuteNonQuery();
                    //
                        string query = $"SELECT * FROM nhanvien";
                        SqlDataAdapter da = new SqlDataAdapter(query, cnn);
                        DataTable dtbl = new DataTable();
                        da.Fill(dtbl);
                        tableNhanVien.DataSource = dtbl;
                    //
                    MessageBox.Show("Thêm thành công!");
                }
                cnn.Close();
            }
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
            TextNVClear();
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            int admin = (boxAdmin.Checked == true) ? 1 : 0;
            string queryNV = $"UPDATE nhanvien SET username = '{txtUsername.Text}', password = '{txtPass.Text}', email = '{txtEmail.Text}', full_name = '{txtTenNV.Text}', address = '{txtAddress.Text}', phone = '{txtPhoneNV.Text}', admin = '{admin}' WHERE id = '{txtMaNV.Text}'";
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
            MessageBox.Show("Sửa thành công!");
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string queryNV = $"DELETE FROM nhanvien WHERE id = '{txtMaNV.Text}'";
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
            TextNVClear();
            MessageBox.Show("Xoá thành công!");
        }
        public Form RefToMain { get; set; }
        private void navBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (navBar.SelectedTab == dangxuatTab)
            {
                this.Dispose();
                this.RefToMain.Show();
            }
        }

        private void btnAddHH_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenHH.Text) || String.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập username và password!!!");
            }
            else
            {
                SqlConnection cnn = new SqlConnection(connectionString);
                string queryNV = $"INSERT INTO hanghoa (tenhanghoa,soluong,loai,dongia,ghichu) VALUES ('{txtTenHH.Text}','{soluongHH.Value}','{loai}','{txtDonGia.Text}','{txtGhichu.Text}')";
                SqlCommand cmd = new SqlCommand(queryNV, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                // update table
                    string query = $"SELECT * FROM hanghoa";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnn);
                    DataTable dtbl = new DataTable();
                    da.Fill(dtbl);
                    tableHangHoa.DataSource = dtbl;
                //
                cnn.Close();
                TextNVClear();
                MessageBox.Show("Thêm thành công!");
                cnn.Close();
            }
        }
    }
}
