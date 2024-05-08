
using System.Data.SqlClient;

using System.Windows.Forms;

namespace SupermarketManagment.Scripts.User
{
    public partial class ResetPassword : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private string username;

        public ResetPassword(string username)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.username = username;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if(txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Passwords didn match", "POS");
                return;
            }
            dBConnect.ExecuteQuery("UPDATE tbUser SET password = '" + txtNewPass.Text + "' " +
                "WHERE username = '"+ username + "'");
            this.Dispose();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
    }
}
