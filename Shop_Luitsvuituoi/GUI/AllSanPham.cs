using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Luitsvuituoi.GUI
{
    public partial class AllSanPham : Form
    {
        public AllSanPham()
        {
            InitializeComponent();
        }
        private string Loai;
        private string Ghichu;
        private string Soluong;
        private string Dongia;
        public string MaHH { get { return txtMaHH.Text; } }
        public string TenHH { get { return txtTenHH.Text; } } 
        public string LoaiHH { get { return Loai; } } 
        public string GhiChuHH { get { return Ghichu; } } 
        public string SoLuongHH { get { return Soluong; } } 
        public string DonGiaHH { get { return Dongia; } } 
        private void AllSP_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = $"SELECT * FROM hanghoa";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableHangHoa.DataSource = dtbl;
        }

        private void tableHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tableHangHoa.CurrentRow.Selected = true;
            txtMaHH.Text = tableHangHoa.Rows[e.RowIndex].Cells["id_hh"].Value.ToString();
            txtTenHH.Text = tableHangHoa.Rows[e.RowIndex].Cells["tenhanghoa"].Value.ToString();
            //bind data
            Loai = tableHangHoa.Rows[e.RowIndex].Cells["loai"].Value.ToString();
            Ghichu = tableHangHoa.Rows[e.RowIndex].Cells["ghichu"].Value.ToString();
            Soluong = tableHangHoa.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
            Dongia = tableHangHoa.Rows[e.RowIndex].Cells["dongia"].Value.ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; // dòng này để chứa lại giá trị khi bấm nút chọn 
            this.Close();
        }
    }
}
