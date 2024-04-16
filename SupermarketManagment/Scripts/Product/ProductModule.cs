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
    public partial class ProductModule : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();

        private Product product;
        private string SaveConfirmMessage = "Are you sure you want to save this product?";
        private string UpdateConfirmMessage = "Are you sure you want to update this product";
        public ProductModule(Product product)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.product = product;
            LoadBrand();
            LoadCategory();
        }
        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cboCategory.DataSource = dBConnect.GetTable("SELECT * FROM tbCategory");
            cboCategory.DisplayMember = "category";
            cboCategory.ValueMember = "id";
        }
        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cboBrand.DataSource = dBConnect.GetTable("SELECT * FROM tbBrand");
            cboBrand.DisplayMember = "brand";
            cboBrand.ValueMember = "id";
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
            txtProductCode.Clear();
            txtBarcode.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            cboBrand.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            UDReorder.Value = UDReorder.Minimum;

            txtProductCode.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtProductCode.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(SaveConfirmMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tbProduct(pcode, barcode, description, brand, category, price, reorder)VALUES(@pcode,@barcode,@description,@brand,@category,@price,@reorder)", cn);
                    cmd.Parameters.AddWithValue("@pcode", txtProductCode.Text);
                    cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@brand", cboBrand.SelectedValue);
                    cmd.Parameters.AddWithValue("@category", cboCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@reorder", UDReorder.Value);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successful saved.", "POS");
                    Clear();
                    product.LoadProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(SaveConfirmMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("UPDATE tbProduct SET barcode=@barcode, description = @description, brand = @brand, category = @category, price = @price, reorder = @reorder WHERE pcode LIKE @pcode", cn);
                    cmd.Parameters.AddWithValue("@pcode", txtProductCode.Text);
                    cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@brand", cboBrand.SelectedValue);
                    cmd.Parameters.AddWithValue("@category", cboCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@reorder", UDReorder.Value);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successful saved.", "POS");
                    Clear();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
