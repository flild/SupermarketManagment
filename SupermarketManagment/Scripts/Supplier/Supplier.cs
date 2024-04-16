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

namespace SupermarketManagment.Scripts.Supplier
{
    public partial class Supplier : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        public Supplier()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadSupplier();
        }
        public void LoadSupplier()
        {
            int i = 0;
            dgvSupplier.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbSupplier", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvSupplier.Rows.Add(i,
                                     dr[0].ToString(),
                                     dr[1].ToString(),
                                     dr[2].ToString(),
                                     dr[3].ToString(),
                                     dr[4].ToString(),
                                     dr[5].ToString(),
                                     dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierModule moduleForm = new SupplierModule(this);
            moduleForm.ShowDialog();
        }
    }
}
