using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SupermarketManagment
{
    public partial class Recept : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        public Recept()
        {
            InitializeComponent();
        }

        private void Recept_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
