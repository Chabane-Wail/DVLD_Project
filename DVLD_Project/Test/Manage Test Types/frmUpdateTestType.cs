using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Aplecations.Manage_Test_Types
{
    public partial class frmUpdateTestType : Form
    {

        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _ApplicationType;

        public frmUpdateTestType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;

        }

      
        

        private void button2_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _ApplicationType.Title = label2.Text.Trim();
            _ApplicationType.Fees = Convert.ToSingle(label3.Text.Trim());


            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmUpdateTestType_Load_1(object sender, EventArgs e)
        {
            label1.Text = _ApplicationTypeID.ToString();

            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                label2.Text = _ApplicationType.Title;
                label3.Text = _ApplicationType.Fees.ToString();


            }
        }
    }
     
    
}
