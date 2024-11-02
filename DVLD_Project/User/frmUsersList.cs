using DVLD_Business;
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
    public partial class frmUsersList : Form
    {


        private static DataTable _dtAllUsers;




 


        public frmUsersList()
        {
            InitializeComponent();
            getAllUsers();


        }



        private void getAllUsers()
        {

            dataGridView1.DataSource=clsUser.GetAllUsers();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void frmUsersList_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox1.SelectedIndex = 0;
            _dtAllUsers = clsUser.GetAllUsers();
            dataGridView1.DataSource = _dtAllUsers;
            label2.Text = dataGridView1.Rows.Count.ToString();



            dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 350;

                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[3].Width = 120;

                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 120;

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateUser Frm1 = new frmAddAndUpdateUser( );
            Frm1.ShowDialog();
            frmUsersList_Load(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( comboBox1.SelectedIndex == 1 ) 
            {
             
                textBox1.Enabled = true;

            
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form Frm1 = new frmChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {




        }
    }
}
