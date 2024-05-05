using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SupermarketManagment.Scripts.Cashier
{
    public partial class DailySale : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private string soldUser;

        public DailySale(string soldUser)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadCashier();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashier");
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbUser WHERE role LIKE 'Cashier'", cn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cboCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadSold()
        {
            int i = 0;
            double total = 0;
            dgvSold.Rows.Clear();
            cn.Open();
            if (cboCashier.Text == "All Cashier")
            {
                string qaury = "SELECT c.id, c.transactionno, c.pcode, p.description, c.price, c.qty, c.discount, c.total " +
                    "FROM tbCart as c " +
                    "INNER JOIN tbProduct AS p on c.pcode = p.pcode " +
                    "WHERE status LIKE 'Sold' " +
                    "AND sdate BETWEEN '" + dateFrom.Value.ToString("M.dd.yyyy") + "' " +
                    "AND '" + dateTo.Value.ToString("M.dd.yyyy") + "'";
                //
                cmd = new SqlCommand(qaury, cn);
                
            }

            else
            {
                cmd = new SqlCommand("SELECT c.id, c.transactionno, c.pcode, p.description, c.price, c.qty, c.discount, c.total " +
                    "FROM tbCart as c " +
                    "INNER JOIN tbProduct AS p on c.pcode = p.pcode " +
                    "WHERE status LIKE 'Sold' " +
                    "AND sdate BETWEEN '" + dateFrom.Value.ToString("M.dd.yyyy") + "' " +
                    "AND '" + dateTo.Value.ToString("M.dd.yyyy") + "' " +
                    "AND cashier LIKE '" + cboCashier.Text + "'", cn);
            }
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                total += double.Parse(dr["total"].ToString());
                dgvSold.Rows.Add(i,
                                 dr["id"].ToString(),
                                 dr["transactionno"].ToString(),
                                 dr["pcode"].ToString(),
                                 dr["description"].ToString(),
                                 dr["price"].ToString(),
                                 dr["qty"].ToString(),
                                 dr["discount"].ToString(),
                                 dr["total"].ToString());
            }
            dr.Close();
            cn.Close();
            lblTotal.Text = total.ToString("#,##0.00");
            
        }

        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void DailySale_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void dgvSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSold.Columns[e.ColumnIndex].Name;
            if(colName == "Cancel")
            {
                CancelOrder cancelOrder = new CancelOrder(this);
                cancelOrder.txtID.Text = dgvSold.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancelOrder.txtTransactionNo.Text = dgvSold.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancelOrder.txtPcode.Text = dgvSold.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancelOrder.txtDescription.Text = dgvSold.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancelOrder.txtPrice.Text = dgvSold.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancelOrder.txtQty.Text = dgvSold.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancelOrder.txtDiscount.Text = dgvSold.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancelOrder.txtTotal.Text = dgvSold.Rows[e.RowIndex].Cells[8].Value.ToString();
                cancelOrder.txtCanceledBy.Text = soldUser;
                cancelOrder.ShowDialog();

            }
        }
    }
}
