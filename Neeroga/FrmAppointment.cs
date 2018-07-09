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

            //Load Speacialization
            SqlCommand selectSp = new SqlCommand("Select Catogary_Id, Catogary_Type from Speacialization", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = selectSp;
            DataTable dt_Sp = new DataTable();
            SqlDataReader reader = selectSp.ExecuteReader();
            dt_Sp.Load(reader);
            reader.Close();
            CmbSpecial.DataSource = dt_Sp;
            CmbSpecial.ValueMember = "Catogary_Id";
            CmbSpecial.DisplayMember = "Catogary_Type";

            //Load Hospitals

            SqlCommand selectHospital = new SqlCommand("Select Hospital_Id, Hospital_Name from Hospital_Details", conn);
            SqlDataAdapter sda1 = new SqlDataAdapter();
            sda1.SelectCommand = selectHospital;
            DataTable dt_Hospital = new DataTable();
            reader = selectHospital.ExecuteReader();
            dt_Hospital.Load(reader);
            reader.Close();
            CmbHospital.DataSource = dt_Hospital;
            CmbHospital.ValueMember = "Hospital_Id";
            CmbHospital.DisplayMember = "Hospital_Name";

            //Load Timeslot
            SqlCommand selectSlot = new SqlCommand("Select Slot_Id, Slot_Time from Time_Slot", conn);
            SqlDataAdapter sda2 = new SqlDataAdapter();
            sda2.SelectCommand = selectSlot;
            DataTable dt_Slot = new DataTable();
            reader = selectSlot.ExecuteReader();
            dt_Slot.Load(reader);
            reader.Close();
            CmbSlot.DataSource = dt_Slot;
            CmbSlot.ValueMember = "Slot_Id";
            CmbSlot.DisplayMember = "Slot_Time";

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
                if (CmbSpecial.Text == "")
                {
                    MessageBox.Show("Please Enter Specialization", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (CmbHospital.Text == "")
                {
                    MessageBox.Show("Please Select Hospital Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand insertcmd = new SqlCommand("INSERT INTO Appointments VALUES (@Appointment_Id, @Patient_Id, @DrAvailability_Id, @Slot_Id, @Date, @Status)", conn);
                    insertcmd.Parameters.Add(new SqlParameter("Appointment_Id", txtAppointId.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("Patient_Id", CmbPatient.SelectedValue));
                    insertcmd.Parameters.Add(new SqlParameter("DrAvailability_Id", CmbDoctor.SelectedValue));
                    insertcmd.Parameters.Add(new SqlParameter("Slot_Id", CmbSlot.SelectedValue));
                    //insertcmd.Parameters.Add(new SqlParameter("Hospital", CmbHospital.SelectedValue));
                    insertcmd.Parameters.Add(new SqlParameter("Date", AppointDate.Value));
                    insertcmd.Parameters.Add(new SqlParameter("Status", "Booked"));

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

        private void CmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AppointDate_ValueChanged(object sender, EventArgs e)
        {
            list_doctors();
        }

        void list_doctors()
        {

            //Load Doctors
            SqlCommand selectAv = new SqlCommand("Select Doctor_Id, DrAvailability_Id from DoctorAvailability where Day='Monday'", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = selectAv;
            DataTable dt_Av = new DataTable();
            SqlDataReader reader = selectAv.ExecuteReader();
            dt_Av.Load(reader);
            reader.Close();
            CmbDoctor.DataSource = dt_Av;
            CmbDoctor.ValueMember = "DrAvailability_Id";
            CmbDoctor.DisplayMember = "Doctor_Id";
        }
    }
}
