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

namespace DemoDisconnectedLayer
{
    public partial class frmMyStore : Form
    {
        public frmMyStore()
        {
            InitializeComponent();
        }
        //Create a Dataset to store data
        DataSet dsMyStore = new DataSet();

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            //Show Products table
            dgvData.DataSource = dsMyStore.Tables[0];
        }

        private void btnViewCategories_Click(object sender, EventArgs e)
        {
            //Show Categories table
            dgvData.DataSource = dsMyStore.Tables[1];
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmMyStore_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Server=(local);uid=Quang;pwd=12345678;database=MyStore";
            string sql = "Select ProductID,ProductName,UnitsInStock From Products; Select * From Categories";
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,ConnectionString);
                dataAdapter.Fill(dsMyStore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Data From Database");
            }
        }
    }
}
