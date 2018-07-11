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

            ////Load Timeslot
            //SqlCommand selectSlot = new SqlCommand("Select Slot_Id, Slot_Time from Time_Slot", conn);
            //SqlDataAdapter sda2 = new SqlDataAdapter();
            //sda2.SelectCommand = selectSlot;
            //DataTable dt_Slot = new DataTable();
            //reader = selectSlot.ExecuteReader();
            //dt_Slot.Load(reader);
            //reader.Close();
            //CmbSlot.DataSource = dt_Slot;
            //CmbSlot.ValueMember = "Slot_Id";
            //CmbSlot.DisplayMember = "Slot_Time";

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
            string dayToCheck = AppointDate.Value.DayOfWeek.ToString();
            
            //Load Doctors
            SqlCommand selectAv = new SqlCommand("Select Doctor_Id, DrAvailability_Id from DoctorAvailability where Day='" + dayToCheck + "' and Catogary_Id='" + CmbSpecial.SelectedValue + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = selectAv;
            DataTable dt_Av = new DataTable();
            SqlDataReader reader = selectAv.ExecuteReader();
            dt_Av.Load(reader);
            reader.Close();
            CmbDoctor.DataSource = dt_Av;
            //DataRow dr = dt_Av.NewRow();
            //dr[0] = "";
            //dr[1] = "";      
            
            //dt_Av.Rows.InsertAt(dr, 0);
            CmbDoctor.ValueMember = "DrAvailability_Id";
            CmbDoctor.DisplayMember = "Doctor_Id";
            //CmbDoctor.SelectedIndex = -1;
            CmbSlot.DataSource = null;
            CmbSlot.Items.Clear();
        }

        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //list_slots();
        }

        void list_slots()
        {
            CmbSlot.DataSource = null;
            CmbSlot.Items.Clear();
            try 
            {

                Application.DoEvents();
            if (CmbDoctor.SelectedValue != null)
            {
            //Get Doctors Schedule
            SqlCommand selectCommand = new SqlCommand("Select Start_time, End_time from DoctorAvailability where DrAvailability_Id=@DrAva_Id", conn);

            string count = CmbDoctor.SelectedValue.ToString();
            selectCommand.Parameters.Add(new SqlParameter("@DrAva_Id", CmbDoctor.SelectedValue));
            string stTime = null;
            string endTime = null;

            SqlDataAdapter da = new SqlDataAdapter(selectCommand);
            DataTable dt = new DataTable();
                da.Fill(dt);

            SqlDataReader reader = selectCommand.ExecuteReader();
            bool rowFound = reader.HasRows;
            if (rowFound)
            {
                while (reader.Read())
                {
                    stTime = reader[0].ToString().Trim();
                    endTime = reader[1].ToString().Trim();
                }
            }
            reader.Close();

            SqlCommand selectSlot = new SqlCommand("SELECT *  FROM Time_Slot WHERE CAST(Slot_Time AS TIME) BETWEEN @stTime AND @endTime", conn);
            selectSlot.Parameters.Add(new SqlParameter("stTime", stTime));
            selectSlot.Parameters.Add(new SqlParameter("endTime", endTime));
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = selectSlot;
            DataTable dt_slot = new DataTable();
            reader = selectSlot.ExecuteReader();
            dt_slot.Load(reader);
            reader.Close();

            //Filter Slots from Appointment
            string A_date = Convert.ToDateTime(AppointDate.Value.Date).ToString("yyyy-MM-dd");
            SqlCommand selectSlotApp = new SqlCommand("SELECT Slot_Id FROM Appointments WHERE DrAvailability_Id=@DrAvId and Date=@AppDate", conn);
            selectSlotApp.Parameters.Add(new SqlParameter("DrAvId", CmbDoctor.SelectedValue));
            selectSlotApp.Parameters.Add(new SqlParameter("AppDate", A_date));

            SqlDataAdapter sda1 = new SqlDataAdapter(selectSlotApp);
            //sda1.SelectCommand = selectSlotApp;
            DataTable dt_slotApp = new DataTable();
            //reader = selectSlotApp.ExecuteReader();
            //dt_slotApp.Load(reader);
            //reader.Close();

            sda1.Fill(dt_slotApp);

            foreach (DataRow row in dt_slot.Rows)
            {
                string Sl_id = row["Slot_Id"].ToString();
                string find = "Slot_Id = '" + Sl_id + "'";
                DataRow[] foundRows = dt_slotApp.Select(find);
                if(foundRows.Length > 0)
                {
                    row.Delete();
                }
                
            }
                dt_slot.AcceptChanges();


                if (dt_slot.Rows.Count == 0)
                {
                    MessageBox.Show("No slots left for selected doctor", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CmbSlot.DataSource = dt_slot;
                    CmbSlot.ValueMember = "Slot_Id";
                    CmbSlot.DisplayMember = "Slot_Time";
                }          


            }
          }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list_slots();
        }        
    }
}
