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
using SupermarketManagment.Scripts.CashierSpace;

namespace SupermarketManagment.Scripts.User
{
    public partial class Login : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        private string password = "";
        private bool isActive;

        public Login()
        {
            cn = new SqlConnection(dBConnect.MyConnection());
            InitializeComponent();
            txtName.Focus();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _username = "";
            string _name = "";
            string _role = "";
            try
            {
                bool isFound;
                cn.Open();
                cmd = new SqlCommand("SELECT * FROM tbUser WHERE username = @username and password = @password", cn);
                cmd.Parameters.AddWithValue("@username", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    isFound = true;
                    _username = dr["username"].ToString();
                    _name = dr["name"].ToString();
                    _role = dr["role"].ToString();
                    password = dr["password"].ToString();
                    isActive = bool.Parse(dr["isactive"].ToString());
                }
                else
                {
                    isFound = false;
                }
                dr.Close();
                cn.Close();

                if(isFound)
                {
                    if(!isActive)
                    {
                        MessageBox.Show("Account is inactive. Unable to login", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtName.Clear();
                    txtPassword.Clear();
                    this.Hide();
                    if (_role == "Cashier")
                    {
                        CashierClass cashier = new CashierClass();
                        cashier.lblUsername.Text = _username;
                        cashier.lblNameRole.Text = _name + " | " + _role;
                        cashier.ShowDialog();
                    }
                    else
                    {   
                        MainForm mainForm = new MainForm();
                        mainForm.lblUsername.Text = _username;
                        mainForm.lblName.Text = _name;
                        mainForm.ShowDialog();
                    }
                }
                else
                {
                    cn.Close();
                    MessageBox.Show("Invalid username or password", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();
            txtName.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) //enter
            {
                btnLogin.PerformClick();
            }
        }
    }
}
