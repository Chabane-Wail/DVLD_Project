using DVLD_Project.Aplecation;
using DVLD_Project.Aplecations.Driving_Licenses_Servises;
using DVLD_Project.Aplecations.International_License;
using DVLD_Project.Aplecations.Licenses.Detain_License;
using DVLD_Project.Aplecations.Manage_Aplecation;
using DVLD_Project.Aplecations.Renew_Local_License;
using DVLD_Project.Aplecations.ReplaceLostOrDamagedLicense;
using DVLD_Project.Aplecations.Rlease_Detained_License;
using DVLD_Project.Drivers;
using DVLD_Project.People;
using DVLD_Project.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmForm1 : Form
    {


        frmMain _frmMain;
        public frmForm1(frmMain frm)
        {
            InitializeComponent();
            _frmMain = frm;
        }

        private void pepeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListPeople();
            frm.ShowDialog();


        }

        private void manageAplecationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm =new frmUsersList();
            frm.ShowDialog();



        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             
            Form frm = new frmMain();
            frm.Show();
            this.Close();

        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmShowPersonInfo(clsGlobel.CurrentUser.PersonID);
            frm.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword(clsGlobel.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageAplecationTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageAplecationTypes();
            frm.Show();

        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmManageTestType();
            frm.Show();


        }

        private void newLoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drivingLeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();


        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLocal_Driving_License_Applications();
            frm.ShowDialog();
        }

        private void drToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();

        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }
    }
}
