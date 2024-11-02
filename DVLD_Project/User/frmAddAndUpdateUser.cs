using DVLD_Business;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Project.frmAddAndUpdateUser;

namespace DVLD_Project
{
    public partial class frmAddAndUpdateUser : Form
    {



        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;




        private int _UserID = -1;
        clsUser _User;

        public frmAddAndUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }


       
       public frmAddAndUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;


        }



        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                label1.Text = "Add New User";
                this.Text = "Add New User";

                tabPage2.Enabled=false; 

                _User = new clsUser();

                
                cntPersonCart1.FilterFocus();
            }
            else
            {
                label1.Text = "Update User";
                this.Text = "Update User";

                tabPage2.Enabled = true;
                button3.Enabled = true;


            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox1.Checked = true;


        }

        private void _LoadData()
        {

            _User = clsUser.FindByUserID(_UserID);
            cntPersonCart1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            label6.Text = _User.UserID.ToString();
            textBox1.Text = _User.UserName;
            textBox2.Text = clsUtil.Decrypt(_User.Password, clsUtil.key);
            textBox3.Text = _User.Password;
            checkBox1.Checked = _User.IsActive;
            cntPersonCart1.LoadPersonInfo(_User.PersonID);
        }










        private void frmAddAndUpdateUser_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();




        }




 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsUser.isUserExist(cntPersonCart1.PersonID)) 
            {

                MessageBox.Show("This Person Is Already User", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }


            tabControl1.SelectedIndex = 1;

            tabPage2.Enabled=true;
        }

        private void button3_Click(object sender, EventArgs e)
        {



            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = cntPersonCart1.PersonID;
            _User.UserName = textBox1.Text.Trim();
            _User.Password = clsUtil.Encrypt(textBox2.Text.Trim(), clsUtil.key);
            _User.IsActive = checkBox1.Checked;


            if (_User.Save())
            {
                label6.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                label1.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


             

        }

        private void cntPersonCart1_Load(object sender, EventArgs e)
        {
            cntPersonCart1.FilterFocus();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (textBox3.Text.Trim() != textBox2.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(textBox3, null);
            };


        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(textBox2, null);
            };



        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            };


            if (_Mode == enMode.AddNew)
            {

                if (clsUser.isUserExist(textBox1.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox1, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(textBox1, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != textBox1.Text.Trim())
                {
                    if (clsUser.isUserExist(textBox1.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(textBox1, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, null);
                    };
                }


            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
