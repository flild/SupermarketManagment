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
    public partial class Discount : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private CashierClass cashier;


        public Discount(CashierClass cashier)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.cashier = cashier;
            this.KeyPreview = true;
            txtDiscount.Focus();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Dispose();
            else if (e.KeyCode == Keys.Enter) btnConfirm.PerformClick();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = double.Parse(txtTotalPrice.Text) * double.Parse(txtDiscount.Text)*0.01;
                txtDiscountAmount.Text = discount.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                txtDiscountAmount.Text = "0.00";
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("add discount& Click yes to confirm", "POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("UPDATE tbCart SET discount_percent = @discount_percent " +
                        "WHERE id = @id", cn);
                    cmd.Parameters.AddWithValue("@discount_percent", double.Parse(txtDiscount.Text));
                    cmd.Parameters.AddWithValue("@id", double.Parse(lblId.Text));
                    cmd.ExecuteNonQuery();
                    cn.Close();
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
    }
}
