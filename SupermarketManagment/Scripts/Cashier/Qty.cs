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
            if ((e.KeyChar == 13) && (txtQty.Text != string.Empty))
            {
                cn.Open();
                cmd = new SqlCommand("INSERT INTO tbCart(transactionno,pcode,price,qty,sdate, cashier) VALUES(@transactionno,@pcode,@price,@qty,@sdate,@cashier)", cn);

                cmd.Parameters.AddWithValue("@transactionno", transactionNo);
                cmd.Parameters.AddWithValue("@pcode", pcode);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@cashier", cashier.lblUsername.Text);

                cmd.ExecuteNonQuery();
                cn.Close();
                cashier.LoadCart();
                this.Dispose();
            }
        }
    }
}
