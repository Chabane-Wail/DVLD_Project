using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Project
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmtest_Load(object sender, EventArgs e)
        {

             
            string UserName = "", Password = "";

            if (clsGlobel.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();



        }


        private void isreal()
        {
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(),clsUtil.Encrypt (txtPassword.Text.Trim(),clsUtil.key));

            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobel.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsGlobel.RememberUsernameAndPassword("", "");

                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobel.CurrentUser = user;
                this.Hide();
                frmForm1 frm = new frmForm1(this);
                frm.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }











        private void btnLogin_Click(object sender, EventArgs e)
        {

             



            isreal();
             



        }



       


        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {





        }
    }
}
