using DVLD_Business;
using DVLD_Project.Aplecations.Globel_Classe;
using DVLD_Project.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Aplecations.Driving_Licenses_Servises
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;










        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                comboBox1.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.AddNew)
            {

                label1.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();
                cntPersonCartWhithFilter1.FilterFocus();
                tabPage2.Enabled = false;

                comboBox1.SelectedIndex = 2;
                label9.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                label7.Text = DateTime.Now.ToShortDateString();
                label8.Text = clsGlobel.CurrentUser.UserName;
            }
            else
            {
                label1.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tabPage2.Enabled = true;
                button3.Enabled = true;


            }

        }

        private void _LoadData()
        {

            cntPersonCartWhithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            cntPersonCartWhithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            label6.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            label7.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            comboBox1.SelectedIndex = comboBox1.FindString(clsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            label9.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            label8.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            cntPersonCartWhithFilter1.LoadPersonInfo(PersonID);


        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }

        }

       

          

        


         






         
         
  
        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenseClasses.Find(comboBox1.Text).LicenseClassID;


            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (clsLicense.IsLicenseExistByPersonID(cntPersonCartWhithFilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = cntPersonCartWhithFilter1.PersonID; ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(label9.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobel.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                label6.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                label1.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);





        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (_Mode == enMode.Update)
            {
                button3.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (cntPersonCartWhithFilter1.PersonID != -1)
            {

                button3.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cntPersonCartWhithFilter1.FilterFocus();
            }








        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated_1(object sender, EventArgs e)
        {
            cntPersonCartWhithFilter1.FilterFocus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cntPersonCartWhithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
    }
}
