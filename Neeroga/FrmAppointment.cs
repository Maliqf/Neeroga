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
    public partial class FrmAppointment : Form
    {
        SqlConnection conn;
        public FrmAppointment()
        {
            InitializeComponent();
            DBConnection dbcon = new Neeroga.DBConnection();
            conn = dbcon.getConnection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmAppointment_Load(object sender, EventArgs e)
        {
            SqlCommand cmdCount = new SqlCommand
                    ("select count(*) from Appointments", conn);
            int count = (((int)cmdCount.ExecuteScalar()) + 1);

            if (count < 10)
            {
                txtAppointId.Text = "A000" + count.ToString();
            }
            else if (count < 100)
            {
                txtAppointId.Text = "A00" + count.ToString();
            }
            else if (count < 1000)
            {
                txtAppointId.Text = "A0" + count.ToString();
            }
            else
            {
                txtAppointId.Text = "A" + count.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (CmbDoctor.Text == "")
                {
                    MessageBox.Show("Please Select Doctor Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (TxtSpeacial.Text == "")
                {
                    MessageBox.Show("Please Enter Specialization", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (CmbHospital.Text == "")
                {
                    MessageBox.Show("Please Select Hospital Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand insertcmd = new SqlCommand("INSERT INTO Appointments VALUES (@Appointment_Id, @Patient_Id, @Doctors_Id, @Speacialization, @Hospital, @Date)", conn);
                    insertcmd.Parameters.Add(new SqlParameter("Appointment_Id", txtAppointId.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("Patient_Id", label7.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("Doctors_Id", CmbDoctor.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("Speacialization", TxtSpeacial.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("Hospital", CmbHospital.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("Date", AppointDate.Value));

                    int row = insertcmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("successfully inserted", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error data not inserted", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
