using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SupermarketManagment.Scripts.Category;
using SupermarketManagment.Scripts.Supplier;
using SupermarketManagment.Scripts.User;
using SupermarketManagment.Scripts.Stock;

namespace SupermarketManagment
{
    public partial class MainForm : Form
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DBConnect dBConnect = new DBConnect();
        private Form activeForm = null;

        public MainForm()
        {
            InitializeComponent();
            CustomizeDesign();
            cn = new SqlConnection(dBConnect.MyConnection());
            cn.Open();
        }

        #region panelSlide
        private void CustomizeDesign()
        {
            panelSubProduct.Visible = false;
            panelSubRecord.Visible = false;
            panelSubStock.Visible = false;
            panelSubSettings.Visible = false;
        }
        private void HideSubmenu()
        {
            if (panelSubProduct.Visible)
                panelSubProduct.Visible = false;
            if (panelSubRecord.Visible)
                panelSubRecord.Visible = false;
            if (panelSubStock.Visible)
                panelSubStock.Visible = false;
            if (panelSubSettings.Visible)
                panelSubSettings.Visible = false;
        }

        private void ShowSubMenu(Panel submenu)
        {
            if (!submenu.Visible)
            {
                HideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion

        
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubProduct);
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            openChildForm(new Product());
            HideSubmenu();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new Category());
            HideSubmenu();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            openChildForm(new Brand());
            HideSubmenu();
        }

        private void btnInStock_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubStock);
        }

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            openChildForm(new StockIn());
            HideSubmenu();
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new Supplier());
            HideSubmenu();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubRecord);
        }

        private void btnSaleHistory_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void btnPOSRecord_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubSettings);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserAccount());
            HideSubmenu();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            HideSubmenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            HideSubmenu();
            if (MessageBox.Show("Logout application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }
    }
}
