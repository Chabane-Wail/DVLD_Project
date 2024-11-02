using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Aplecations.Local_Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();


        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonLicenseHistory_Load_1(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                cntPersonCartWhithFilter1.LoadPersonInfo(_PersonID);
                cntPersonCartWhithFilter1.FilterEnabled = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                cntPersonCartWhithFilter1.Enabled = true;
                cntPersonCartWhithFilter1.FilterFocus();
            }

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void cntPersonCartWhithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }
    }
}
