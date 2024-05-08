using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagment.Scripts.User
{
    public partial class UserAccount : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private string username;
        private string name;
        private string role;
        private string accStatus;



        private string SaveAccConfirmMessage = "Are you sure you want to save this account?";

        public UserAccount(string username)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            lblUsername.Text = username;
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbUser", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i,
                                    dr[0].ToString(),
                                    dr[3].ToString(),
                                    bool.Parse(dr[4].ToString()) ? "Actived" : "Deactivated",
                                    dr[2].ToString());
                dgvUser[3, i-1].Style.BackColor = bool.Parse(dr[4].ToString()) ? Color.Green : Color.Red;
            }
            dr.Close();
            cn.Close();
        }
        public void Clear()
        {
            txtFullName.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            txtUserName.Clear();
            CboRole.Text = "";
            txtUserName.Focus();
        }
        private void btnAccSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRePassword.Text)
            {
                MessageBox.Show("Password did not March!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (MessageBox.Show(SaveAccConfirmMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tbUser(username, password, role, name)VALUES(@username, @password, @role, @name)", cn);
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@role", CboRole.Text);
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                    
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("new account been successful addded.", "POS");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCurPassword.Text != dBConnect.GetPassword(lblUsername.Text))
                {
                    MessageBox.Show("Wrong password", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(txtNewPassword.Text != txtNewRePassword.Text)
                {
                    MessageBox.Show("Password didnt mathed", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dBConnect.ExecuteQuery("UPDATE tbUser SET password = '" + txtNewPassword.Text + "' " +
                    "WHERE username = '" + lblUsername.Text + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelPassword_Click(object sender, EventArgs e)
        {
            ClearCP();
        }
        public void ClearCP()
        {
            txtCurPassword.Clear();
            txtNewPassword.Clear();
            txtNewRePassword.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dBConnect.ExecuteQuery("DELETE FROM tbUser WHERE username = '" + username + "'");
            LoadUser();
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvUser.CurrentRow.Index;
            dgvUser.Rows[i].Selected = true;
            username = dgvUser[1,i].Value.ToString();
            name = dgvUser[2, i].Value.ToString();
            role = dgvUser[4, i].Value.ToString();
            accStatus = dgvUser[3, i].Value.ToString();
            if(lblUsername.Text == username)
            {
                btnRemove.Enabled = false;
                btnResetPassword.Enabled = false;
                lblAccountNote.Text = "To change your password, go to change password tag";
            }
            else
            {
                btnRemove.Enabled = true;
                btnResetPassword.Enabled = true;
                lblAccountNote.Text = "To change the password for " + username + ", click \"Reset password\"";
            }
            gbUser.Text = "Password for " +username;
            
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword(username);
            resetPassword.ShowDialog();
        }

        private void btnPropert_Click(object sender, EventArgs e)
        {
            UserProperties properties = new UserProperties();
            properties.txtFullName.Text = name;
            properties.CboRole.Text = role;
            properties.cboActivate.Text = accStatus;
            properties.ShowDialog();
        }
    }
}
