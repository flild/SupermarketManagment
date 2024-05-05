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

namespace SupermarketManagment.Scripts.Cashier
{
    public partial class CancelOrder : Form
    {
        private DailySale dailySale;

        public CancelOrder(DailySale dailySale)
        {
            InitializeComponent();
            this.dailySale = dailySale;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(cboAddInventory.Text != String.Empty && udCancelQty.Value > 0 && txtReason.Text != String.Empty)
                {
                    if(int.Parse(txtQty.Text) >= udCancelQty.Value)
                    {
                        Void voidWindow = new Void(this);
                        voidWindow.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ReloadSoldList()
        {
            dailySale.LoadSold();
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboAddInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
