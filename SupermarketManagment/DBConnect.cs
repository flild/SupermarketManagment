using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagment
{
    public class DBConnect
    {
        private string con;
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        public string MyConnection()
        {
            con = @"Data Source=(local);Initial Catalog=DBPOSale;Integrated Security=True";
            return con;
        }
        public DataTable GetTable(string query)
        {
            cn.ConnectionString = MyConnection();
            cmd = new SqlCommand(query, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void ExecuteQuery(string sql)
        {
            try
            {
                cn.ConnectionString = MyConnection();
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
