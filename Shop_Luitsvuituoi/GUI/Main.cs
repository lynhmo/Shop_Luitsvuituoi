using Shop_Luitsvuituoi.GUI;
using System;
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
        private void Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(960, 540);
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
    }
}
