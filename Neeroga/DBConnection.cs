using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Neeroga
{
    class DBConnection
    {
        public SqlConnection getConnection()
        {
            SqlConnection conn = null;

            try
            {
                //if you connect to a db @home uncomment the below line
                // conn = new SqlConnection("data source=DB; initial catalogu=Net; Integrated Security

                //conn = new SqlConnection(@"data source=ACER-PC\SQLEXPRESS; initial catalog=WAD_HND76_39  ; user id=sa; password=M@liqf@27");
                conn = new SqlConnection(@"data source=SRICEWKS01008\SQLEXPRESS01; initial catalog=WAD_76_39; user id=MQ; password=M@liq@inno1");
                conn.Open();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error in Connection");
                MessageBox.Show("Error in Connection" + ex, "Customer Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
    }
}
