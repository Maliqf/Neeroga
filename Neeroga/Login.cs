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
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            DBConnection dbcon = new Neeroga.DBConnection();
            conn = dbcon.getConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try 
            {
                SqlCommand selectCommand = new SqlCommand("Select User_Type, User_Id from Users where User_Name=@UserName and Password=@Password", conn);
                selectCommand.Parameters.Add(new SqlParameter("UserName", username.Text.ToString()));
                selectCommand.Parameters.Add(new SqlParameter("Password", password.Text.ToString()));
                string userType = null;
                string userId = null;
                SqlDataReader reader = selectCommand.ExecuteReader();
                bool rowFound = reader.HasRows;
                if (rowFound)
                {
                    while (reader.Read())
                    {
                        userType = reader[0].ToString().Trim();
                        userId = reader[1].ToString().Trim();
                        this.Hide();
                        Home objHome = new Home();
                        objHome.User.Text = username.Text;
                        objHome.lblUserId.Text = userId;
                        objHome.UserType.Text = userType;
                        objHome.Show();

                    }
                    /*
                    if (userType == "Admin")
                    {
                        MessageBox.Show("Admin ", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (userType == "Manager")
                    {
                        MessageBox.Show("Manager ", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (userType == "Doctor")
                    {
                        MessageBox.Show("Doctor ", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    */
                }
                else
                {
                    MessageBox.Show("User not found", "Data Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Search" + ex, "Catch Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
