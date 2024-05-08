using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SupermarketManagment.Scripts.CashierSpace;

namespace SupermarketManagment.Scripts.Cashier
{
    public partial class ChangePassword : Form
    {
        private DBConnect dBConnect = new DBConnect();
        public ChangePassword(string username)
        {
            InitializeComponent();
            lblUsername.Text = username;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPassword = dBConnect.GetPassword(lblUsername.Text);
                if(oldPassword != txtCurrentPassword.Text) 
                {
                    MessageBox.Show("Wrong password, please try again!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    SwitchToNewPasswordForm();
                }
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
        private void SwitchToNewPasswordForm()
        {
            txtCurrentPassword.Visible = false;
            btnNext.Visible = false;

            txtNewPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password didnt mathed", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    dBConnect.ExecuteQuery("UPDATE tbUser SET password = '" + txtNewPassword.Text + "' " +
                        "WHERE username = '" + lblUsername.Text + "'");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
