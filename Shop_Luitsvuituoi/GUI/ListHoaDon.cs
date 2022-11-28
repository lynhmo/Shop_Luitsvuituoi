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
    public partial class ListHoaDon : Form
    {
        public ListHoaDon()
        {
            InitializeComponent();
        }

        private void ListHoaDon_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            string query = $"SELECT * FROM hoadon";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            tableHoaDon.DataSource = dtbl;
        }

        private void tableHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tableHoaDon.CurrentRow.Selected = true;
                //take out values from table to textbox
                //txtMaKhachHang.Text = tableKhachHang.Rows[e.RowIndex].Cells["id_KH"].Value.ToString();
                //txtTenKhachHang.Text = tableKhachHang.Rows[e.RowIndex].Cells["tenKhachhang"].Value.ToString();
                //_KH_phone = tableKhachHang.Rows[e.RowIndex].Cells["phone"].Value.ToString();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
