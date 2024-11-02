using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD_Project.User
{
    public partial class frmChangePassword : Form
    {

     private   clsUser _User;

        private int _UserId;
        

        public frmChangePassword(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

            
            _User.Password = clsUtil.Encrypt(textBox3.Text.Trim(), clsUtil.key);
           


            if (_User.Save())
            {

                //change form mode to update.

                _ResetDefualtValues();
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (_User.Password!= clsUtil.Encrypt(textBox1.Text.Trim(), clsUtil.key)) 
            {

                errorProvider1.SetError(textBox1, "Password Is Roung");
            }
            else 
            {

                errorProvider1.SetError(textBox1, null);
            }


        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {

                errorProvider1.SetError(textBox3, "Password Is Roung");
            }
            else
            {

                errorProvider1.SetError(textBox3, null);
            }
        }

        private void cntPersonCart1_Load(object sender, EventArgs e)
        {

        }



        private void _ResetDefualtValues()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

           

            _User=clsUser.FindByUserID(_UserId);

            

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with Id = " + _UserId,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }

            cntPersonCart1.LoadPersonInfo(_User.PersonID);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {


            if (textBox2.Text =="")
            {

                errorProvider1.SetError(textBox2, "Password Is emty");
            }
            else
            {

                errorProvider1.SetError(textBox2, null);
            }



        }
    }
}
