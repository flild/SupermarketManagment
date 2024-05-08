using SupermarketManagment.Scripts.Cashier;
using SupermarketManagment.Scripts.User;
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
    public partial class CashierClass : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        private int qty;
        private string id;
        private string price;
        public CashierClass()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            GetTransactionNo();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit application?","Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public void slide(Button button)
        {
            panelSlide.BackColor = Color.White;
            panelSlide.Height = button.Height;
            panelSlide.Top = button.Top;
        }


        #region Buttons
        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            slide(btnNewTransaction);
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            slide(btnSearchProduct);
            LookUpProduct lookUp = new LookUpProduct(this);
            lookUp.LoadProduct();
            lookUp.ShowDialog();
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            slide(btnAddDiscount);
            Discount discount = new Discount(this);
            discount.lblId.Text = id;
            discount.txtTotalPrice.Text = price;
            discount.ShowDialog();
        }

        private void btnSettlePayment_Click(object sender, EventArgs e)
        {
            slide(btnSettlePayment);
            Settle settle = new Settle(this);
            settle.txtSale.Text = lblDisplayTotal.Text;
            settle.ShowDialog();

        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            slide(btnClearCart);
            if (MessageBox.Show("Remove all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cmd = new SqlCommand("DELETE from tbCart WHERE transactionno LIKE '" + lblTransactionNo.Text + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("All items has been successfully remove", "Remove item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCart();
            }

        }

        private void btnDailySales_Click(object sender, EventArgs e)
        {
            slide(btnDailySales);
            DailySale dailySale = new DailySale(lblUsername.Text);
            dailySale.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            slide(btnChangePassword);
            ChangePassword changePass = new ChangePassword(lblUsername.Text);
            changePass.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            slide(btnLogout);
            if(dgvCashier.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout. Please cancel the transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Logout application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        #endregion
        public void LoadCart()
        {
            try
            {
                bool hasCart = false;
                int i = 0;
                double total = 0;
                double discount = 0;
                dgvCashier.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("SELECT c.id, c.pcode, p.description, c.price, c.qty, c.discount, c.total " +
                                    "FROM tbCart AS c " +
                                    "INNER JOIN tbProduct AS p ON c.pcode = p.pcode" +
                                    " WHERE c.transactionno LIKE @transactionno and c.status LIKE 'Pending'", cn);
                cmd.Parameters.AddWithValue("@transactionno", lblTransactionNo.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    total += Convert.ToDouble(dr["total"].ToString());
                    discount += Convert.ToDouble(dr["discount"].ToString());
                    dgvCashier.Rows.Add(i,
                                        dr["id"].ToString(),
                                        dr["pcode"].ToString(),
                                        dr["description"].ToString(),
                                        dr["price"].ToString(),
                                        dr["qty"].ToString(),
                                        dr["discount"].ToString(),
                                        double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    hasCart = true;
                }
                dr.Close();
                cn.Close();
                lblSalesTotal.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                if(hasCart)
                {
                    btnClearCart.Enabled = true;
                    btnSettlePayment.Enabled = true;
                    btnAddDiscount.Enabled = true;
                }
                else
                {
                    btnClearCart.Enabled = false;
                    btnSettlePayment.Enabled = false;
                    btnAddDiscount.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void GetCartTotal()
        {
            double discount = double.Parse(lblDiscount.Text);
            double sales = double.Parse(lblSalesTotal.Text) - discount;
            double vat = sales * Constant.vatPercent; //VAT: 12%of VAT payeble (output Tax less input Tax)
            double vatable = sales - vat;

            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            lblDisplayTotal.Text = sales.ToString("#,##0.00");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        public void GetTransactionNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transacctionNo = sdate + "1001";
                lblTransactionNo.Text = transacctionNo;
                cn.Open();
                cmd = new SqlCommand("SELECT TOP 1 transactionno FROM tbCart" +
                                    " WHERE transactionno LIKE '" + sdate + "%' " +
                                    "ORDER BY id DESC", cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transacctionNo = dr[0].ToString();
                    count = int.Parse((transacctionNo.Substring(8, 4)));
                    lblTransactionNo.Text = sdate + (count + 1);
                }
                else
                {
                    transacctionNo = sdate + "1001";
                    lblTransactionNo.Text = transacctionNo;
                }
                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBarcode.Text == String.Empty) return;
                else
                {
                    string _pcode;
                    double _price;
                    int _qty;

                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM tbProduct WHERE barcode LIKE '" + txtBarcode.Text +"'", cn);
                    dr=cmd.ExecuteReader();
                    dr.Read();
                    if(dr.HasRows)
                    {
                        qty = int.Parse(dr["qty"].ToString());
                        _pcode = dr["pcode"].ToString();
                        _price = double.Parse(dr["price"].ToString());
                        _qty = int.Parse(txtQty.Text);
                        dr.Close();
                        cn.Close();
                        AddToCard(_pcode, _price, _qty);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AddToCard(string _pcode, double _price, int _qty)
        {
            try
            {
                string id = "";
                int cart_qty = 0;
                bool isFound = false;
                cn.Open();
                cmd = new SqlCommand("SELECT * FROM tbCart WHERE transactionno = @transactionno AND pcode = @pcode", cn);
                cmd.Parameters.AddWithValue("@transactionno", lblTransactionNo.Text);
                cmd.Parameters.AddWithValue("@pcode", _pcode);
                dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
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
                    MessageBox.Show("Unable to procced. Remaining quantity on hand is " + qty, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (isFound)
                {
                    cn.Open();
                    cmd = new SqlCommand("UPDATE tbCart set qty = (qty + " + _qty + ") WHERE id = '" + id + "'", cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    txtBarcode.SelectionStart = 0;
                    txtBarcode.SelectionLength = txtBarcode.Text.Length;
                    LoadCart();
                }
                
                else
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tbCart(transactionno, pcode, price, qty, sdate, cashier) " +
                    "VALUES(@transactionno, @pcode, @price, @qty, @sdate, @cashier)", cn);
                    cmd.Parameters.AddWithValue("@transactionno", lblTransactionNo.Text);
                    cmd.Parameters.AddWithValue("@pcode", _pcode);
                    cmd.Parameters.AddWithValue("@price", _price);
                    cmd.Parameters.AddWithValue("@qty", _qty);
                    cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@cashier", lblUsername.Text);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    LoadCart();

                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCashier_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvCashier.CurrentRow.Index;
            id = dgvCashier[1,i].Value.ToString();
            price = dgvCashier[7, i].Value.ToString();
        }

        private void dgvCashier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCashier.Columns[e.ColumnIndex].Name;
            int i = 0;


            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dBConnect.ExecuteQuery("DELETE from tbCart WHERE id LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("Item has been successfully removed", "Remove item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCart();
                }
            }
            else if(colName == "colAdd")
            {
                cn.Open();
                cmd = new SqlCommand("SELECT SUM(qty) AS qty FROM tbProduct " +
                    "WHERE pcode LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "' GROUP BY pcode", cn);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close();
                if (int.Parse(dgvCashier.Rows[e.RowIndex].Cells[5].Value.ToString()) <i)
                {
                    dBConnect.ExecuteQuery("UPDATE tbCart SET qty = qty + " + int.Parse(txtQty.Text) +
                        "WHERE transactionno LIKE '" + lblTransactionNo.Text + 
                        "' AND pcode LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "'");
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Remaining qty on hand is " + i + "!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "colReduce")
            {
                cn.Open();
                cmd = new SqlCommand("SELECT SUM(qty) AS qty FROM tbCart " +
                    "WHERE pcode LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "' GROUP BY pcode", cn);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close();
                if (i > 1)
                {
                    dBConnect.ExecuteQuery("UPDATE tbCart SET qty = qty - " + int.Parse(txtQty.Text)+
                        "WHERE transactionno LIKE '" + lblTransactionNo.Text +
                        "' AND pcode LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "'");
                    LoadCart();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
