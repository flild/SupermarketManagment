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

namespace SupermarketManagment.Scripts.CashierSpace
{
    public partial class Qty : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private string pcode;
        private double price;
        private string transactionNo;
        private int qty;
        Cashier cashier;

        public Qty(Cashier cashier)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.cashier = cashier;
        }
        public void ProductDetails(string pcode, double price, string transactionNo, int qty)
        {
            this.pcode = pcode;
            this.price = price;
            this.transactionNo = transactionNo;
            this.qty = qty;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar == 13) && (txtQty.Text != String.Empty))
            {
                try
                {
                    string id = "";
                    int cart_qty = 0;
                    bool isFound = false;
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM tbCart WHERE transactionno = @transactionno AND pcode = @pcode", cn);
                    cmd.Parameters.AddWithValue("@transactionno", transactionNo);
                    cmd.Parameters.AddWithValue("@pcode", pcode);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        id = dr["id"].ToString();
                        cart_qty = int.Parse(dr["qty"].ToString());
                        isFound = true;
                    }
                    else
                    {
                        isFound = false;
                    }
                    dr.Close();
                    cn.Close();

                    if (qty < (int.Parse(txtQty.Text) + cart_qty))
                    {
                        MessageBox.Show("Unable to procced. Remaining qty on hand is " + qty, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (isFound)
                    {
                        cn.Open();
                        cmd = new SqlCommand("UPDATE tbCart set qty = (qty + " + int.Parse(txtQty.Text) + ") WHERE id = '" + id + "'", cn);

                        cmd.ExecuteNonQuery();
                        cn.Close();
                        cashier.LoadCart();
                        cashier.txtBarcode.Clear();
                        cashier.txtBarcode.Focus();
                        this.Dispose();
                    }

                    else
                    {
                        cn.Open();
                        cmd = new SqlCommand("INSERT INTO tbCart(transactionno, pcode, price, qty, sdate, cashier) " +
                        "VALUES(@transactionno, @pcode, @price, @qty, @sdate, @cashier)", cn);
                        cmd.Parameters.AddWithValue("@transactionno", transactionNo);
                        cmd.Parameters.AddWithValue("@pcode", pcode);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                        cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@cashier", cashier.lblUsername.Text);

                        cmd.ExecuteNonQuery();
                        cn.Close();
                        cashier.txtBarcode.Clear();
                        cashier.txtBarcode.Focus();
                        cashier.LoadCart();
                        this.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            /////////////////////////////////////////////////////////////
        }
    }
}
