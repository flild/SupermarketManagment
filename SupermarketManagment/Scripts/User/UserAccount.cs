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

namespace SupermarketManagment.Scripts.User
{
    public partial class UserAccount : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        private string SaveAccConfirmMessage = "Are you sure you want to save this account?";

        public UserAccount()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
