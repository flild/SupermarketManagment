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

namespace SupermarketManagment.Scripts.Stock
{
    public partial class StockIn : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private SqlDataReader dr;

        public StockIn()
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            LoadSupplier();
            GetReferenceNo();
        }

        public void GetReferenceNo()
        {
            Random rnd = new Random();
            txtReferenceNo.Clear();
            txtReferenceNo.Text += rnd.Next();
        }
        public void LoadSupplier()
        {
            cboSupplier.Items.Clear();
            cboSupplier.DataSource = dBConnect.GetTable("SELECT * FROM tbSupplier");
            cboSupplier.DisplayMember = "supplier";
        }
        public void LoadStockIn()
        {
            int i = 0;
            dgvStockIn.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM vwStockIn WHERE refno LIKE '" +txtReferenceNo.Text + "' " +
                "AND status LIKE 'Pending'", cn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvStockIn.Rows.Add(i,
                                    dr[0].ToString(),//id
                                    dr[1].ToString(),//refno
                                    dr[2].ToString(),//pcode
                                    dr[3].ToString(),//description
                                    dr[4].ToString(),//qty
                                    dr[5].ToString(),//sdate
                                    dr[6].ToString(),//stockinby
                                    dr[8].ToString());//supplier
            }
            dr.Close();
            cn.Close();
        }
        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbSupplier WHERE supplier LIKE '" + cboSupplier.Text + "'", cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if(dr.HasRows)
            {
                lblId.Text = dr["id"].ToString();
                txtContactPerson.Text = dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();
            }
            dr.Close();
            cn.Close();
        }

        private void cboSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void linkGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetReferenceNo();
        }

        private void linkProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductStockIn productStock = new ProductStockIn(this);
            productStock.ShowDialog();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvStockIn.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this records?", "POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //update product quantity
                        for(int i = 0; i < dgvStockIn.Rows.Count; i++)
                        {
                            cn.Open();
                            cmd = new SqlCommand("UPDATE tbProduct SET qty = qty + " + int.Parse(dgvStockIn.Rows[i].Cells[5].Value.ToString()) +
                                "WHERE pcode LIKE '" + dgvStockIn.Rows[i].Cells[3].Value.ToString() + "'",cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();

                            cn.Open();
                            cmd = new SqlCommand("UPDATE tbStockIn SET qty = qty + " + int.Parse(dgvStockIn.Rows[i].Cells[5].Value.ToString()) +
                                ", status = 'Done' WHERE id LIKE '" + dgvStockIn.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                        Clear();
                        LoadStockIn();
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"POS",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            txtReferenceNo.Clear();
            txtStockInBy.Clear();
            dtStockIn.Value = DateTime.Now;
        }

        private void dgvStockIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStockIn.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if(MessageBox.Show("Remove this item?", "POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbStockIn " +
                                        "WHERE id ='" + dgvStockIn.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has been successfully removed", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStockIn();
                }
            }
        }
    }
}
