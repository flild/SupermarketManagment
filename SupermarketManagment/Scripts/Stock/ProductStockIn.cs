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

namespace SupermarketManagment.Scripts.Stock
{
    public partial class ProductStockIn : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private StockIn stockIn;

        public ProductStockIn(StockIn stockIn)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadProduct();
            this.stockIn = stockIn;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand(
                "SELECT pcode, description, qty FROM tbProduct " +
                "WHERE description LIKE '%" + txtSearch.Text + "%'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i,
                                    dr[0].ToString(),
                                    dr[1].ToString(),
                                    dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if(colName == "Select")
            {
                if(stockIn.txtStockInBy.Text == string.Empty)
                {
                    MessageBox.Show("Please enter stock in by name", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stockIn.txtStockInBy.Focus();
                    this.Dispose();
                }
                if(MessageBox.Show("Add this item?", "POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cn.Open();
                        cmd = new SqlCommand("INSERT INTO tbStockIn(refno,pcode,sdate,stockinby,supplierid) " +
                            "VALUES(@refno,@pcode,@sdate,@stockinby,@supplierid)",cn);
                        cmd.Parameters.AddWithValue("@refno",stockIn.txtReferenceNo.Text);
                        cmd.Parameters.AddWithValue("@pcode", dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@sdate", stockIn.dtStockIn.Value);
                        cmd.Parameters.AddWithValue("@stockinby", stockIn.txtStockInBy.Text);
                        cmd.Parameters.AddWithValue("@supplierid", stockIn.lblId.Text);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        stockIn.LoadStockIn();
                        MessageBox.Show("Successfully added", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "POS");
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
