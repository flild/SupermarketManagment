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

namespace SupermarketManagment.Scripts.Store
{
    public partial class StoreClass : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;
        private bool hasStoreInfo = false;

        public StoreClass()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadStore();
        }
        public void LoadStore()
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("SELECT * FROM tbStore",cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    hasStoreInfo = true;
                    txtStoreName.Text = dr["store"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                }
                else
                {
                    txtStoreName.Clear();
                    txtAddress.Clear();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cn.Close() ;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(hasStoreInfo)
                {
                    dBConnect.ExecuteQuery("UPDATE tbStore SET " +
                        "store = '" + txtStoreName.Text + "', address = '" +txtAddress.Text + "'");
                }
                else
                {
                    dBConnect.ExecuteQuery("INSERT INTO tbStore (store,address) " +
                        "VALUES ('" + txtStoreName.Text + "','" + txtAddress.Text + "')");
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void StoreClass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose ();
            }
        }
    }
}
