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

namespace SupermarketManagment.Scripts.Cashier
{
    public partial class LookUpProduct : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private Cashier cashier;

        public LookUpProduct(Cashier cashier)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadProduct();
            this.cashier = cashier;
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
                "SELECT p.pcode, p.barcode, p.description, b.brand, c.category, p.price, p.qty " +
                "FROM tbProduct AS p INNER JOIN tbBrand AS b ON b.id = p.brand " +
                "INNER JOIN tbCategory AS c on c.id = p.category " +
                "WHERE CONCAT(p.description, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
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

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvProduct.Columns[e.ColumnIndex].Name;
            if(ColName == "Select")
            {
                Qty qty = new Qty(cashier);
                qty.ProductDetails(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    double.Parse(dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString()),
                    cashier.lblTransactionNo.Text,
                    int.Parse(dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString()));
                qty.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void LookUpProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
