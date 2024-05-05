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
    public partial class Void : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private CancelOrder cancelOrder;
        public Void(CancelOrder cancelOrder)
        {
            cn = new SqlConnection(dBConnect.MyConnection());
            InitializeComponent();
            this.cancelOrder = cancelOrder;
            txtName.Focus();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text == cancelOrder.txtCanceledBy.Text)
                {
                    MessageBox.Show("Void by name and cancelled by name are same. \n Please void by another person",
                        "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string user;
                cn.Open();
                cmd = new SqlCommand("SELECT * FROM tbUser WHERE username = @username and password = @password", cn);
                cmd.Parameters.AddWithValue("@username", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    user = dr["username"].ToString();
                    dr.Close();
                    cn.Close();
                    SaveCancelOrder(user);
                    if(cancelOrder.cboAddInventory.Text == "yes")
                    {
                        dBConnect.ExecuteQuery("UPDATE tbProduct SET qty = qty + "+ cancelOrder.udCancelQty.Value +" " +
                            "WHERE pcode = '" +cancelOrder.txtPcode.Text + "'");
                    }
                    dBConnect.ExecuteQuery("UPDATE tbCart SET qty = qty + " + cancelOrder.udCancelQty.Value + " " +
                            "WHERE id LIKE '" + cancelOrder.txtID.Text + "'");
                    this.Dispose();
                    cancelOrder.ReloadSoldList();
                    cancelOrder.Dispose();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SaveCancelOrder(string user)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("INSERT INTO tbCancel" +
                    "(transactionno, pcode, price, qty, total, sdate, voidby, cancelledby, reason, action)" +
                    "VALUES (@transactionno, @pcode, @price, @qty, @total, @sdate, @voidby, @cancelledby, @reason, @action)", cn);
                cmd.Parameters.AddWithValue("@transactionno",cancelOrder.txtTransactionNo);
                cmd.Parameters.AddWithValue("@pcode", cancelOrder.txtPcode.Text);
                cmd.Parameters.AddWithValue("@price", double.Parse(cancelOrder.txtPrice.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(cancelOrder.txtQty.Text));
                cmd.Parameters.AddWithValue("@total", int.Parse(cancelOrder.txtTotal.Text));
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@voidby", user);
                cmd.Parameters.AddWithValue("@cancelledby", cancelOrder.txtCanceledBy.Text);
                cmd.Parameters.AddWithValue("@reason", cancelOrder.txtReason);
                cmd.Parameters.AddWithValue("@action", cancelOrder.cboAddInventory.Text);
                cmd.ExecuteNonQuery();
                cn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
