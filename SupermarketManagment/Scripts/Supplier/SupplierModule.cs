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
    public partial class SupplierModule : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();

        private Supplier supplier;
        private string SaveConfirmMessage = "Are you sure you want to save this supplier?";
        private string UpdateConfirmMessage = "Are you sure you want to update this supplier";


        public SupplierModule(Supplier supplier)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.supplier = supplier;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(UpdateConfirmMessage, "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("UPDATE tbSupplier SET supplier = @supplier,address=@address, contactperson = @contactperson, phone = @phone,email=@email, telegram = @telegram WHERE id = @id", cn);
                    cmd.Parameters.AddWithValue("@id", lblId.Text);
                    cmd.Parameters.AddWithValue("@supplier", txtSupplierName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@contactperson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhoneNum.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@telegram", txtTelegram.Text);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successful updated.", "POS");
                    this.Dispose();
                    supplier.LoadSupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(SaveConfirmMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tbSupplier(supplier, address, contactperson, phone, email, telegram)VALUES(@supplier, @address, @contactperson, @phone, @email, @telegram)", cn);
                    cmd.Parameters.AddWithValue("@supplier", txtSupplierName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@contactperson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhoneNum.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@telegram", txtTelegram.Text);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successful saved.", "POS");
                    Clear();
                    supplier.LoadSupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtSupplierName.Clear();
            txtAddress.Clear();
            txtContactPerson.Clear();
            txtPhoneNum.Clear();
            txtemail.Clear();
            txtTelegram.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtSupplierName.Focus();
        }
    }
}
