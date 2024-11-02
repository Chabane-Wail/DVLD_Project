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
    public partial class frmManageAplecationTypes : Form
    {

        private DataTable _dtAllApplicationTypes;
        public frmManageAplecationTypes()
        {
            InitializeComponent();
           

        }

        private void RefrachdataGridView1()
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            dataGridView1.DataSource = _dtAllApplicationTypes;
        }





        private void frmManageAplecationTypes_Load(object sender, EventArgs e)
        {
            RefrachdataGridView1();


            label2.Text = dataGridView1.RowCount.ToString();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 110;

            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[1].Width = 400;

            dataGridView1.Columns[2].HeaderText = "Fees";
            dataGridView1.Columns[2].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateAplecationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm= new frmUpdateAplecationType((int)dataGridView1.CurrentRow.Cells[0].Value);


            frm.ShowDialog();

            RefrachdataGridView1();
        }
    }
}
