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
    public partial class Product : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        private string deleteConfirmMessage = "Are you sure you want to delete this record?";

        public Product()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand(
                "SELECT p.pcode, p.barcode, p.description, b.brand, c.category, p.price, p.reorder " +
                "FROM tbProduct AS p INNER JOIN tbBrand AS b ON b.id = p.brand " +
                "INNER JOIN tbCategory AS c ON c.id = p.category " +
                "WHERE CONCAT(p.description, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", cn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i,
                                    dr[0].ToString(),
                                    dr[1].ToString(),
                                    dr[2].ToString(),
                                    dr[3].ToString(),
                                    dr[4].ToString(),
                                    dr[5].ToString(),
                                    dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule moduleForm = new ProductModule(this);
            moduleForm.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show(deleteConfirmMessage, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbProduct WHERE pcode LIKE '" + dgvProduct[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "Edit")
            {
                ProductModule module = new ProductModule(this);
                module.txtProductCode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtBarcode.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtDescription.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.cboBrand.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.cboCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                module.UDReorder.Value = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString());

                module.txtProductCode.Enabled = false;
                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
