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
    public partial class Settle : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private CashierClass cashier;

        public Settle(CashierClass cashier)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.KeyPreview = true;
            this.cashier = cashier;
        }

        private void ButtonHandler(Button button, object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(button.Text))
            {
                txtCash.Text += button.Text;
            }
        }

        #region NumberButtonsHendler
        private void btnOne_Click(object sender, EventArgs e) { ButtonHandler(btnOne, sender, e); }
        private void btnTwo_Click(object sender, EventArgs e) { ButtonHandler(btnTwo, sender, e); }
        private void btnThree_Click(object sender, EventArgs e) { ButtonHandler(btnThree, sender, e); }
        private void btnFour_Click(object sender, EventArgs e) { ButtonHandler(btnFour, sender, e); }
        private void btnFive_Click(object sender, EventArgs e) { ButtonHandler(btnFive, sender, e); }
        private void btnSix_Click(object sender, EventArgs e) { ButtonHandler(btnSix, sender, e); }
        private void btnSeven_Click(object sender, EventArgs e) { ButtonHandler(btnSeven, sender, e); }
        private void btnEight_Click(object sender, EventArgs e) { ButtonHandler(btnEight, sender, e); }
        private void btnNine_Click(object sender, EventArgs e) { ButtonHandler(btnNine, sender, e); }
        private void BtnZero_Click(object sender, EventArgs e) { ButtonHandler(BtnZero, sender, e); }
        private void btnZeroZero_Click(object sender, EventArgs e) { ButtonHandler(btnZeroZero, sender, e); } 
        #endregion
        #region говнокод с ютуба
        /* private void btnOne_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnOne.Text;
 }

 private void btnTwo_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnTwo.Text;
 }

 private void btnThree_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnThree.Text;
 }

 private void btnFour_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnFour.Text;
 }

 private void btnFive_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnFive.Text;
 }

 private void btnSix_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnSix.Text;
 }

 private void btnSeven_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnSeven.Text;
 }

 private void btnEight_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnEight.Text;
 }

 private void btnNine_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnNine.Text;
 }

 private void BtnZero_Click(object sender, EventArgs e)
 {
     txtCash.Text += BtnZero.Text;
 }

 private void btnZeroZero_Click(object sender, EventArgs e)
 {
     txtCash.Text += btnZeroZero.Text;
 }*/

        #endregion
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCash.Clear();
            txtCash.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if ((double.Parse(txtChange.Text) < 0) || (txtCash.Text.Equals("")))
                {
                    MessageBox.Show("Infsufficient amount. Please enter correct amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for(int i = 0; i < cashier.dgvCashier.Rows.Count; i++)
                    {
                        cn.Open();
                        cmd = new SqlCommand("UPDATE tbProduct SET qty = qty - " + int.Parse(cashier.dgvCashier.Rows[i].Cells[5].Value.ToString()) + 
                            "WHERE pcode = '" + cashier.dgvCashier.Rows[i].Cells[2].Value.ToString() + "'", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cmd = new SqlCommand("UPDATE tbCart SET status = 'Sold' "+
                            "WHERE id = '" + cashier.dgvCashier.Rows[i].Cells[1].Value.ToString() + "'", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    MessageBox.Show("Payment succefully saved!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cashier.GetTransactionNo();
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
        private void Settle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Dispose();
            else if (e.KeyCode == Keys.Enter) btnEnter.PerformClick();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sale = double.Parse(txtSale.Text);
                double cash = double.Parse(txtCash.Text);
                double charge = cash - sale;
                txtChange.Text = charge.ToString();
            }
            catch (Exception ex)
            {
                txtChange.Text = "0.00";
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
