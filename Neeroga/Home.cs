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

namespace Neeroga
{
    public partial class Home : Form
    {
        SqlConnection conn;
        public Home()
        {
            InitializeComponent();
            DBConnection dbcon = new Neeroga.DBConnection();
            conn = dbcon.getConnection();
        }

       
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers FrmUsr = new FrmUsers();
            FrmUsr.MdiParent = this;
            FrmUsr.label7.Text = UserType.Text;
            FrmUsr.Show();
        }

        private void Home_Load_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Time.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            if (UserType.Text == "Admin")
            {
                
            }
            else if (UserType.Text == "Manager")
            {
                TSRecord.Visible = false;
            }
            else if (UserType.Text == "Doctor")
            {
                TStripMge.Visible = false;
            }
            this.Time.Text = System.DateTime.Now.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointment FrmAppiont = new FrmAppointment();
            FrmAppiont.MdiParent = this;
            if (UserType.Text == "Admin")
            {
                FrmAppiont.label7.Text = UserType.Text;
                //FrmAppiont.txtPatientNme.ReadOnly = true;
            }
            else
            {
                FrmAppiont.label7.Text = UserType.Text;
                FrmAppiont.txtPatientNme.ReadOnly = true;
            }
            FrmAppiont.txtPatientNme.Text = User.Text;
            FrmAppiont.Show();
        }
    }
}
