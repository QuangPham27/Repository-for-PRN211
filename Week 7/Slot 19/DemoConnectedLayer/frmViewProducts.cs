using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoConnectedLayer
{
    public partial class frmViewProducts : Form
    {
        public frmViewProducts()
        {
            InitializeComponent();
        }

        private void frmViewProducts_Load(object sender, EventArgs e)
        {
            //Create a list to store Products
            List<dynamic> products = new List<dynamic>();
            string ConnectionString = "server=(local);database=MyStore;uid=Quang;pwd=12345678";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("Select ProductName, UnitPrice From Products", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    products.Add(new
                    {
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDecimal("UnitPrice")
                    });
                }//end while
                //Binding with DataGridView: dgvData
                dgvData.DataSource = products;
            }//end if
        }//end frmViewProducts_Load

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
