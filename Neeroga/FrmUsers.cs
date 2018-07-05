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
    public partial class FrmUsers : Form
    {
        SqlConnection conn;
        public FrmUsers()
        {
            InitializeComponent();
            DBConnection dbcon = new Neeroga.DBConnection();
            conn = dbcon.getConnection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtUname.Text == "")
                {
                    MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUname.Focus();
                    return;
                }
                else if (TxtPw.Text == "")
                {
                    MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPw.Focus();
                    return;
                }
                else if (CmbUtype.Text == "")
                {
                    MessageBox.Show("Please Select User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPw.Focus();
                    return;
                }
                else
                {
                    
                    SqlCommand insertcmd = new SqlCommand("INSERT INTO Users VALUES (@User_id, @User_Name, @User_Type, @Password)", conn);
                    SqlCommand selectCommand = new SqlCommand("Select User_Type from Users where User_Id=@UserId and User_Name=@UserName", conn);

                    selectCommand.Parameters.Add(new SqlParameter("UserId", TxtUID.Text.ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("UserName", TxtUname.Text.ToString()));

                    insertcmd.Parameters.Add(new SqlParameter("User_id", TxtUID.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("User_Name", TxtUname.Text.ToString()));
                    insertcmd.Parameters.Add(new SqlParameter("User_Type", CmbUtype.SelectedValue));
                    insertcmd.Parameters.Add(new SqlParameter("Password", TxtPw.Text.ToString()));
                    
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    bool rowFound = reader.HasRows;
                    reader.Close();
                    if (rowFound)
                    {
                        MessageBox.Show("User already Exist", "User Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int row = insertcmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            MessageBox.Show("successfully inserted", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load_tabel();
                            generate_id();
                            TxtUname.Text = "";
                            TxtPw.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Error data not inserted", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error data not inserted" + ex, "User Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            load_tabel();
            generate_id();

            //Fill User Type            
            SqlCommand selectUsrType = new SqlCommand("Select UserTypeId, UserType from UserTypes", conn);
            SqlDataAdapter sda1 = new SqlDataAdapter();
            sda1.SelectCommand = selectUsrType;
            DataTable dt_usrT = new DataTable();
            SqlDataReader reader_uTyp = selectUsrType.ExecuteReader();
            dt_usrT.Load(reader_uTyp);
            reader_uTyp.Close();

            CmbUtype.DataSource = dt_usrT;
            CmbUtype.ValueMember = "UserTypeId";
            CmbUtype.DisplayMember = "UserType";

        }


        void generate_id()
        {
            SqlCommand cmdCount = new SqlCommand
                        ("select count(*) from Users", conn);
            int count = (((int)cmdCount.ExecuteScalar()) + 1);

            if (count < 10)
            {
                TxtUID.Text = "U000" + count.ToString();
            }
            else if (count < 100)
            {
                TxtUID.Text = "U00" + count.ToString();
            }
            else if (count < 1000)
            {
                TxtUID.Text = "U0" + count.ToString();
            }
            else
            {
                TxtUID.Text = "U" + count.ToString();
            }
        
        }

        void load_tabel()
        {

            try
            {
                SqlCommand Cmnd = new SqlCommand("select User_Id, User_Name, User_Type from Users", conn);
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

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                TxtUID.Text = row.Cells["User_Id"].Value.ToString();
                TxtUname.Text = row.Cells["User_Name"].Value.ToString();
                CmbUtype.Text = row.Cells["User_Type"].Value.ToString();
            }
        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            try 
            {
                if (TxtUname.Text == "")
                {
                    MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUname.Focus();
                    return;
                }
                else if (TxtPw.Text == "")
                {
                    MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPw.Focus();
                    return;
                }
                else if (CmbUtype.Text == "")
                {
                    MessageBox.Show("Please Select User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPw.Focus();
                    return;
                }
                else
                {
                    SqlCommand updatedcmd = new SqlCommand("Update Users SET [User_Name]=@User_Name, [User_Type]=@User_Type, [Password]=@Password where [User_id]=@User_id", conn);

                    updatedcmd.Parameters.Add(new SqlParameter("User_id", TxtUID.Text.ToString()));
                    updatedcmd.Parameters.Add(new SqlParameter("User_Name", TxtUname.Text.ToString()));
                    updatedcmd.Parameters.Add(new SqlParameter("User_Type", CmbUtype.Text.ToString()));
                    updatedcmd.Parameters.Add(new SqlParameter("Password", TxtPw.Text.ToString()));


                    int row = updatedcmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("successfully Updated", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error data not updated", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
