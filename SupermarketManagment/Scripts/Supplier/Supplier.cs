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

        private string deleteConfirmMessage = "Are you sure you want to delete this record?";
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

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSupplier.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show(deleteConfirmMessage, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbSupplier WHERE id LIKE '" + dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "Edit")
            {
                SupplierModule module = new SupplierModule(this);
                module.lblId.Text = dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtSupplierName.Text = dgvSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtAddress.Text = dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.txtContactPerson.Text = dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.txtPhoneNum.Text = dgvSupplier.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.txtemail.Text = dgvSupplier.Rows[e.RowIndex].Cells[6].Value.ToString();
                module.txtTelegram.Text = dgvSupplier.Rows[e.RowIndex].Cells[7].Value.ToString();

                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            LoadSupplier();
        }
    }
}
