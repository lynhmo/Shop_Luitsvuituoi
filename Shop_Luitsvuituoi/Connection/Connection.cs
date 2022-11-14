using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Luitsvuituoi.Connection
{
    internal class Connection
    {
        public static void DB_connection()
        {
            string connectionString = @"Data Source = localhost; Database = Luitsvuituoi; Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connectionString);
            //cnn.Open();
            //MessageBox.Show("Connection Open  !");
            //cnn.Close();
        }
    }
}
