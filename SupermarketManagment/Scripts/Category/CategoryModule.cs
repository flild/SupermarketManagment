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

namespace SupermarketManagment.Scripts.Category
{
    public partial class CategoryModule : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();

        private Category category;


        public CategoryModule(Category category)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.category = category;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("INSERT INTO tbCategory(category)VALUES(@category)", cn);
                cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                Clear();
                category.LoadCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtCategory.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtCategory.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("UPDATE tbCategory SET category = @category WHERE id LIKE '" + lblId.Text + "'", cn);
            cmd.Parameters.AddWithValue("@category", txtCategory.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            Clear();
            this.Dispose();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
