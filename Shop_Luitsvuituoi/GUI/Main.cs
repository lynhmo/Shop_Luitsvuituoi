using Shop_Luitsvuituoi.GUI;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Shop_Luitsvuituoi
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private static string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
        private static SqlConnection cnn = new SqlConnection(connectionString);
        private void Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(960, 540);
            cnn.Open();
            //table Nhan vien
            load_table_NV();
            //table hang hoa
            load_table_HH();
            // load combobox id hang hoa
            load_id_HH();
            //combobox loai load
            comboboxHH_Loai_Load();
            //combobox nhan vien load
            comboboxNhanVien_Load();
            cnn.Close(); 
        }
        private void load_table_NV()
        {
            string query = $"SELECT * FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableNhanVien.DataSource = dtbl;
        }
        private void load_table_HH()
        {
            string queryHH = $"SELECT * FROM hanghoa";
            SqlDataAdapter daHH = new SqlDataAdapter(queryHH, cnn);
            DataTable tableHH = new DataTable();
            daHH.Fill(tableHH);
            tableHangHoa.DataSource = tableHH;
        }
        private void load_id_HH()
        {
            string querycb = "select id_hh from hanghoa";
            SqlDataAdapter daHHC = new SqlDataAdapter(querycb, cnn);
            DataSet ds = new DataSet();
            daHHC.Fill(ds, "id_hh");
            comboboxMaSP.DisplayMember = "id_hh";
            comboboxMaSP.ValueMember = "id_hh";
            comboboxMaSP.DataSource = ds.Tables["id_hh"];
        }
        private void comboboxNhanVien_Load()
        {
            string cmbNhanvien = "select full_name,id from nhanvien";
            SqlDataAdapter cmbNhanvien_ = new SqlDataAdapter(cmbNhanvien, cnn);
            DataSet ds1 = new DataSet();
            cmbNhanvien_.Fill(ds1, "nhanvienName");
            comboBoxNhanVien.DisplayMember = "full_name";
            comboBoxNhanVien.ValueMember = "id";
            comboBoxNhanVien.DataSource = ds1.Tables["nhanvienName"];
        }
        private void comboboxHH_Loai_Load()
        {
            comboboxLoai.Items.Add("gpu");
            comboboxLoai.Items.Add("ram");
            comboboxLoai.Items.Add("cpu");
            comboboxLoai.Items.Add("keyboard");
            comboboxLoai.Items.Add("mouse");
            comboboxLoai.Items.Add("motherboard");
            comboboxLoai.Items.Add("psu");
            comboboxLoai.Items.Add("cooler");
            comboboxLoai.Items.Add("monitor");
            comboboxLoai.Items.Add("headset");
            comboboxLoai.Items.Add("mouse pad");
            comboboxLoai.Items.Add("laptop");
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
            string tenKH = txtTenKhachHang.Text;
            string phone = txtPhone.Text;
            if (!String.IsNullOrEmpty(tenKH) || !String.IsNullOrEmpty(phone))
            {
                string queryCheck = $"SELECT count(*) FROM khachhang WHERE tenKhachHang= '{tenKH}' AND phone = '{phone}'";
                SqlCommand cmdC = new SqlCommand(queryCheck, cnn);
                cnn.Open();
                int sl = (int)cmdC.ExecuteScalar();
                cnn.Close();
                if (sl >= 1)
                {
                    MessageBox.Show("Khách hàng này đã tồn tại!!!");
                }
                else
                {
                    string query = $"INSERT INTO khachhang (tenKhachHang,phone) VALUES ('{tenKH}','{phone}')";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Thêm khách hàng thành công!", "Thành công");
                }
            }
            else
            {
                MessageBox.Show("Không được để trống tên khách hàng và số điện thoại!","Thất bại");
            }
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
            if (e.RowIndex >= 0)
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
            string theDate = dateTimePickerBirth.Value.ToString("MM/dd/yyyy");
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Thất bại!!! Vui lòng nhập username và password!!!");
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
                    MessageBox.Show("Đã có người đăng ký!!!");
                }
                else
                {
                    int admin = (boxAdmin.Checked == true) ? 1 : 0;
                    string queryNV = $"INSERT INTO nhanvien (username,password,email,full_name,birth,address,phone,admin) VALUES ('{txtUsername.Text}','{txtPass.Text}','{txtEmail.Text}','{txtTenNV.Text}','{theDate}','{txtAddress.Text}','{txtPhoneNV.Text}','{admin}')";
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
        //call back login
        public Form RefToMain { get; set; }
        private void navBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (navBar.SelectedTab == dangxuatTab)
            {
                //sau khi từ chối đăng xuất thì quay trở lại tab đầu tiên
                navBar.SelectTab(0);
                string message = "Bạn có muốn đăng xuất?!";
                string title = "Đăng xuất";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                    this.RefToMain.Show();
                }
                else
                {
                    //sau khi từ chối đăng xuất thì quay trở lại tab đầu tiên
                    //navBar.SelectTab(0);
                }
                
            }
            // refresh lai button khi chuyen qua tab khac
            if (navBar.SelectedTab != banhangTab)
            {
                btnAddSP_toCTHD.Enabled = false;
                btnDeleteSP_toCTHD.Enabled = false;
                btnInHoaDon.Enabled = false;
                btnThanhToan.Enabled = false;
                btnTaoHoaDon.Enabled = true;
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
                string queryNV = $"INSERT INTO hanghoa (tenhanghoa,soluong,loai,dongia,ghichu,baohanh) VALUES ('{txtTenHH.Text}','{Number_soluongHH.Value}','{comboboxLoai.Text}','{txtDonGia.Text}','{txtGhichu.Text}','{sonambaohanh.Value}')";
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
        private void updateTableHanghoa()
        {
            // update table
            string query = $"SELECT * FROM hanghoa";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableHangHoa.DataSource = dtbl;
            //
        }
        private void tableHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tableHangHoa.CurrentRow.Selected = true;
            txtMaHH.Text = tableHangHoa.Rows[e.RowIndex].Cells["id_hh"].Value.ToString();
            txtTenHH.Text = tableHangHoa.Rows[e.RowIndex].Cells["tenhanghoa"].Value.ToString();
            Number_soluongHH.Text = tableHangHoa.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
            comboboxLoai.Text = tableHangHoa.Rows[e.RowIndex].Cells["loai"].Value.ToString();
            txtDonGia.Text = tableHangHoa.Rows[e.RowIndex].Cells["dongia"].Value.ToString();
            txtGhichu.Text = tableHangHoa.Rows[e.RowIndex].Cells["ghichu"].Value.ToString();
            sonambaohanh.Text = tableHangHoa.Rows[e.RowIndex].Cells["baohanh"].Value.ToString();
        }
        private void comboboxLoai_Click(object sender, EventArgs e)
        {
            comboboxLoai.DroppedDown = true;
        }

        private void btnUpdateHH_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string queryHH = $"UPDATE hanghoa SET " +
                $"tenhanghoa = '{txtTenHH.Text}', " +
                $"soluong = '{Number_soluongHH.Value}', " +
                $"loai = '{comboboxLoai.Text}', " +
                $"dongia = '{txtDonGia.Text}', " +
                $"ghichu = '{txtGhichu.Text}', " +
                $"baohanh = '{sonambaohanh.Value}' " +
                $"WHERE id_hh = '{txtMaHH.Text}'";
            SqlCommand cmd = new SqlCommand(queryHH, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            updateTableHanghoa();
            cnn.Close();
            MessageBox.Show("Sửa thành công!");
        }
        private void btnDeleteHH_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string queryNV = $"DELETE FROM hanghoa WHERE id_hh = '{txtMaHH.Text}'";
            SqlCommand cmd = new SqlCommand(queryNV, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            updateTableHanghoa();
            cnn.Close();
            TextNVClear();
            MessageBox.Show("Xoá thành công!");
            ClearTextHangHoa();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void ClearTextHangHoa()
        {
            txtMaHH.Text = null;
            txtTenHH.Text = null;
            Number_soluongHH.Text = null;
            comboboxLoai.Text = null;
            txtDonGia.Text = null;
            txtGhichu.Text = null;
            sonambaohanh.Text = null;
        }

        private void btnRefreshHH_Click(object sender, EventArgs e)
        {
            ClearTextHangHoa();
        }

        private void btnFindHH_Click(object sender, EventArgs e)
        {

        }
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // hàm ngăn chặn form Main đóng mà form login vẫn mở trong background
            this.Dispose();
            this.RefToMain.Show();
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            //MessageBox.Show(theDate);
            if (String.IsNullOrEmpty(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng!!!");
            }
            else
            {
                
                string queryNV = $"INSERT INTO hoadon (makh,nhanvien,tongtien,DateCreated) VALUES ('{txtMaKhachHang.Text}','{comboBoxNhanVien.SelectedValue}',100,'{theDate}')";
                SqlCommand cmd = new SqlCommand(queryNV, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                
                //
                btnTaoHoaDon.Enabled = false;
                btnAddSP_toCTHD.Enabled = true;
                btnDeleteSP_toCTHD.Enabled = true;
                btnInHoaDon.Enabled = true;
                btnThanhToan.Enabled = true;
                //
                SqlCommand commandNV = new SqlCommand("Select id_hd from hoadon where makh=@idKH AND nhanvien=@idNV AND DateCreated=@dateC", cnn);
                commandNV.Parameters.AddWithValue("@idKH", txtMaKhachHang.Text);
                commandNV.Parameters.AddWithValue("@idNV", comboBoxNhanVien.SelectedValue);
                commandNV.Parameters.AddWithValue("@dateC", theDate); 
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = commandNV.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMaHoaDon.Text = String.Format("{0}", reader["id_hd"]);
                        //Console.WriteLine(String.Format("{0}", reader["id"]));
                    }
                }
                //
                cnn.Close();
            }
        }

        private void btnListHoaDon_Click(object sender, EventArgs e)
        {
            ListHoaDon frmCTHD = new ListHoaDon();
            frmCTHD.ShowDialog();
        }

        private void btnAddSP_toCTHD_Click(object sender, EventArgs e)
        {
            cnn.Open();
            if (Convert.ToInt32(numericUpDown1.Value)==0 || txtTenSP.Text == null)
            {
                MessageBox.Show("Không được để trống dữ liệu sản phẩm !!!","Lỗi");
            }
            else
            {
                SqlCommand checkEx = new SqlCommand("SELECT count(*) FROM ChiTietHoaDon WHERE mahoadon= @mahoadon AND mahang= @mahang", cnn);
                checkEx.Parameters.AddWithValue("@mahoadon", txtMaHoaDon.Text);
                checkEx.Parameters.AddWithValue("@mahang", comboboxMaSP.Text);
                int sl = (int)checkEx.ExecuteScalar();
                if (sl == 1)
                {
                    int tongtienUpdate = int.Parse(txtGiaTien.Text) * Convert.ToInt32(numericUpDown1.Value);
                    SqlCommand updateCTHD = new SqlCommand("UPDATE ChiTietHoaDon SET soluong = @soluong ,tong = @tong WHERE mahoadon=@mahoadon AND mahang=@mahang", cnn);
                    updateCTHD.Parameters.AddWithValue("@mahoadon", txtMaHoaDon.Text);
                    updateCTHD.Parameters.AddWithValue("@mahang", comboboxMaSP.Text);
                    updateCTHD.Parameters.AddWithValue("@soluong", numericUpDown1.Value);
                    updateCTHD.Parameters.AddWithValue("@tong", tongtienUpdate);
                    updateCTHD.ExecuteNonQuery();
                }
                else
                {
                    int tongtien = int.Parse(txtGiaTien.Text) * Convert.ToInt32(numericUpDown1.Value);
                    SqlCommand insertCTHD = new SqlCommand("INSERT INTO ChiTietHoaDon VALUES (@mahoadon,@mahang,@soluong,@dongia,@tong)", cnn);
                    insertCTHD.Parameters.AddWithValue("@mahoadon", txtMaHoaDon.Text);
                    insertCTHD.Parameters.AddWithValue("@mahang", comboboxMaSP.Text);
                    insertCTHD.Parameters.AddWithValue("@soluong", numericUpDown1.Value);
                    insertCTHD.Parameters.AddWithValue("@dongia", txtGiaTien.Text);
                    insertCTHD.Parameters.AddWithValue("@tong", tongtien);
                    insertCTHD.ExecuteNonQuery();
                }
                string tableCTHD = $"SELECT * FROM ChiTietHoaDon WHERE mahoadon = '{txtMaHoaDon.Text}'";
                SqlDataAdapter daHD = new SqlDataAdapter(tableCTHD, cnn);
                DataTable tableHD = new DataTable();
                daHD.Fill(tableHD);
                tableHoaDon.DataSource = tableHD;
            }
            cnn.Close();
        }

        private void comboboxMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
