using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            cntPersonCart1.LoadPersonInfo(PersonID);
        }

        private void cntPersonCart1_Load(object sender, EventArgs e)
        {

        }

        private void clsShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
