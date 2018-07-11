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
    public partial class FrmDrSchedule : Form
    {
        SqlConnection conn;
        public FrmDrSchedule()
        {
            InitializeComponent();
            DBConnection dbcon = new Neeroga.DBConnection();
            conn = dbcon.getConnection();
        }

        private void FrmDrSchedule_Load(object sender, EventArgs e)
        {
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
            CmbSpecial.SelectedIndex = -1;

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
            CmbHospital.SelectedIndex = -1;

            load_tabel();
        }

        void load_tabel()
        {

            try
            {
                SqlCommand Cmnd = new SqlCommand("select * from DoctorAvailability where Doctor_Id='" + TxtUID.Text.ToString() + "'", conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = Cmnd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
