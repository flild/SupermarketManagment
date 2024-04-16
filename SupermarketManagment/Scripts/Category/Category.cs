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

namespace SupermarketManagment.Scripts.Category
{
    public partial class Category : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        private string deleteConfirmMessage = "Are you sure you want to delete this record?";
        public Category()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadCategory();
        }
        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbCategory ORDER BY category", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr["id"].ToString(), dr["category"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryModule moduleForm = new CategoryModule(this);
            moduleForm.ShowDialog();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show(deleteConfirmMessage, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbCategory WHERE id LIKE '" + dgvCategory[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("category has been successfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "Edit")
            {
                CategoryModule categoryModule = new CategoryModule(this);
                categoryModule.lblId.Text = dgvCategory[1, e.RowIndex].Value.ToString();
                categoryModule.txtCategory.Text = dgvCategory[2, e.RowIndex].Value.ToString();
                categoryModule.btnSave.Enabled = false;
                categoryModule.btnUpdate.Enabled = true;
                categoryModule.ShowDialog();
            }
            LoadCategory();
        }
    }
}
