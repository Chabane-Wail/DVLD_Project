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

namespace DVLD_Project.Aplecation
{
    public partial class frmUpdateAplecationType : Form
    {

        private int _AplecationId=-1;
        private clsApplicationTypes _ApplicationTypes;

        public frmUpdateAplecationType(int AplecationId)
        {
            InitializeComponent();
            _AplecationId=AplecationId;
        }

        private void frmUpdateAplecationType_Load(object sender, EventArgs e)
        {
            label4.Text= _AplecationId.ToString();
            _ApplicationTypes = clsApplicationTypes.Find(_AplecationId);

            if (_ApplicationTypes != null)
            {
                textBox1.Text = _ApplicationTypes.Title;
                textBox2.Text = _ApplicationTypes.Fees.ToString();


            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ApplicationTypes = clsApplicationTypes.Find(_AplecationId);


            _ApplicationTypes.Title=textBox1.Text.Trim();
            _ApplicationTypes.Fees=Convert.ToSingle( textBox2.Text.Trim());

            if (_ApplicationTypes.Save())
            {
                 
       
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);







        }
    }
}
