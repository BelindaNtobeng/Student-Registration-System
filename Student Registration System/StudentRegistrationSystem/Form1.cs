using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonAddStudents_Click(object sender, EventArgs e)
        {
            Form2 objectForm2 = new Form2();
            objectForm2.Show();
            this.Hide();// close main form
        }

        private void buttonShowStudents_Click(object sender, EventArgs e)
        {
            Form3 objectForm3 = new Form3();
            objectForm3.Show();
            this.Hide();// close main form
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
