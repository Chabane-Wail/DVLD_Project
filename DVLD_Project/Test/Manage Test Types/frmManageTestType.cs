using DVLD_Business;
using DVLD_Project.Aplecations.Manage_Test_Types;
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
    public partial class frmManageTestType : Form
    {
        private DataTable _dtAllApplicationTypes;
        public frmManageTestType()
        {
            InitializeComponent();


        }

      
        private void RefrichdgvTestTypes()
        {

            _dtAllApplicationTypes = clsTestType.GetAllTestTypes();

            dgvTestTypes.DataSource = _dtAllApplicationTypes;
        }





        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsTestType.GetAllTestTypes();
            
            dgvTestTypes.DataSource = _dtAllApplicationTypes;
            label2.Text = dgvTestTypes.Rows.Count.ToString();

            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 120;

            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 200;

            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 400;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefrichdgvTestTypes();
        }
    }
}
