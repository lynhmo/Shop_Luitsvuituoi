using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shop_Luitsvuituoi.GUI
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        private string _KH_phone = "";
        public string Ma_KH { get { return txtMaKhachHang.Text; } }
        public string Ten_KH { get { return txtTenKhachHang.Text; } }
        public string Phone_KH { get { return _KH_phone; } }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; // dòng này để chứa lại giá trị khi bấm nút chọn 
            this.Close();
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = $"SELECT * FROM khachhang";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableKhachHang.DataSource = dtbl;
        }
        private void tableKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tableKhachHang.CurrentRow.Selected = true;
                //take out values from table to textbox
                txtMaKhachHang.Text = tableKhachHang.Rows[e.RowIndex].Cells["id_KH"].Value.ToString();
                txtTenKhachHang.Text = tableKhachHang.Rows[e.RowIndex].Cells["tenKhachhang"].Value.ToString();
                _KH_phone = tableKhachHang.Rows[e.RowIndex].Cells["phone"].Value.ToString();
            }
        }
    }
}
