using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SupermarketManagment.Scripts.User
{
    public partial class UserProperties : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private string username;
        private UserAccount userAccount;
        public UserProperties(string username, UserAccount userAccount)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.username = username;
            this.userAccount = userAccount;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("UPDATE tbUser SET name = @name, role=@role, isactive = @isactive " +
                    "WHERE username = @username",cn);
                cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                cmd.Parameters.AddWithValue("@role", CboRole.Text);
                cmd.Parameters.AddWithValue("@isactive", cboActivate.Text);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
                cn.Close();
                userAccount.LoadUser();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
