using Microsoft.Reporting.WinForms;
using SupermarketManagment.Scripts.CashierSpace;
using System;
using System.Collections.Generic;
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
        private string store;
        private string address;
        private CashierClass cashier;

        public Recept(CashierClass cashier)
        {
            InitializeComponent();
            cn = new SqlConnection(dBConnect.MyConnection());
            this.cashier = cashier;
            LoadStore();


        }
        public void LoadStore()
        {
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbStore",cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if(dr.HasRows)
            {
                store = dr["store"].ToString();
                address = dr["address"].ToString();

            }
            dr.Close();
            cn.Close();
        }
        private void Recept_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        public void LoadRecept(string pcashArg, string pChangeArg)
        {
            ReportDataSource rptDataSource;
            try
            {
                string reportPath = Application.StartupPath + @"\Reports\RptRecept.rdlc";
                this.reportViewer1.LocalReport.ReportPath = reportPath;
                this.reportViewer1.LocalReport.DataSources.Clear();
                
                DataSet1 dataSet = new DataSet1();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                cn.Open();
                string quary = "SELECT cart.id, cart.transactionno, cart.pcode, cart.price, cart.qty, cart.discount, cart.total, cart.sdate, cart.status, p.description " +
                    "FROM tbCart AS cart INNER JOIN tbProduct AS p ON p.pcode = cart.pcode " +
                    "WHERE cart.transactionno LIKE '" + cashier.lblTransactionNo.Text + "'";
                dataAdapter.SelectCommand = new SqlCommand(quary, cn);
                dataAdapter.Fill(dataSet.Tables["dtRecept"]);
                cn.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", cashier.lblVatable.Text);
                ReportParameter pVat = new ReportParameter("pVat", cashier.lblVat.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", cashier.lblDiscount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", cashier.lblDisplayTotal.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcashArg);
                ReportParameter pChange = new ReportParameter("pChange", pChangeArg);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaction","Invoice #:" + cashier.lblTransactionNo.Text);
                ReportParameter pCashier = new ReportParameter("pCashier", cashier.lblUsername.Text);
                
                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pTransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);

                rptDataSource = new ReportDataSource("DataSet1", dataSet.Tables["dtSold"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 30;

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Recept_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
