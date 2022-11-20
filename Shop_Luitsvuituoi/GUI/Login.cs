using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Shop_Luitsvuituoi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local); Initial Catalog = Luitsvuituoi; Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connectionString);
            string pass = txtPass.Text;
            string name = txtUser.Text;
            string query = $"SELECT count(*) FROM nhanvien WHERE username = '{name}' AND password = '{pass}' ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            int sl = (int)cmd.ExecuteScalar();
            if (sl == 1)
            {
                Main main = new Main();
                main.RefToMain = this;
                this.Visible = false;
                main.Show();
            }
            else
            {
                MessageBox.Show("Loi");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}
