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

namespace SupermarketManagment
{
    public partial class Brand : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        private string deleteConfirmMessage = "Are you sure you want to delete this record?";
        public Brand()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadBrand();
        }
        public void LoadBrand()
        {
            int i = 0;
            dgvBrand.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbBrand ORDER BY brand", cn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvBrand.Rows.Add(i, dr["id"].ToString(), dr["brand"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BrandModule moduleForm = new BrandModule(this);
            moduleForm.ShowDialog();
        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBrand.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show(deleteConfirmMessage, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbBrand WHERE id LIKE '" + dgvBrand[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("brand has been successfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "Edit")
            {
                BrandModule brandModule = new BrandModule(this);
                brandModule.lblId.Text = dgvBrand[1, e.RowIndex].Value.ToString();
                brandModule.txtBrand.Text = dgvBrand[2, e.RowIndex].Value.ToString();
                brandModule.btnSave.Enabled = false;
                brandModule.btnUpdate.Enabled = true;
                brandModule.ShowDialog();
            }
            LoadBrand();
        }
    }
}
