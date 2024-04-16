using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagment
{
    public class DBConnect
    {
        private string con;
        public string MyConnection()
        {
            con = @"Data Source=(local);Initial Catalog=DBPOSale;Integrated Security=True";
            return con;
        }
    }
}
