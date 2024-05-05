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

namespace SupermarketManagment
{
    public partial class BrandModule : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();

        private string UpdateConfirmMessage = "Are you sure you want to update this brand";
        private Brand brand;

        public BrandModule(Brand brand)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.brand = brand;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("INSERT INTO tbBrand(brand)VALUES(@brand)",cn);
                cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                Clear();
                brand.LoadBrand();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtBrand.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtBrand.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd =new SqlCommand("UPDATE tbBrand SET brand = @brand WHERE id LIKE '" + lblId.Text + "'", cn);
            cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            Clear();
            this.Dispose();
        }
    }
}
