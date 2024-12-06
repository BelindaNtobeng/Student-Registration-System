using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentRegistrationSystem
{
    public partial class Form2 : Form

    {
        private string[] studentInfo=new string[6];

        public Form2()
        {
            InitializeComponent();
        }

        private void button1Save_Click(object sender, EventArgs e)
        {
            DateTime dob;
            if (!DateTime.TryParse(this.birthDate.Text, out dob)) 
            {
                MessageBox.Show("incorrect date format. Please use the correct format: MM.DD.YYYY");// correct date format for date of birth
                return;
            }
            DateTime jd;
            if (!DateTime.TryParse(joinDate.Text, out jd))
            {
                MessageBox.Show("incorrect date format. Please use the correct format: MM.DD.YYYY");//Correct date format for joining date
                return;
            }
            studentInfo[0]=name.Text;
            studentInfo[1]=lastName.Text;
            studentInfo[2]=sponsorName.Text;
            studentInfo[3]=birthDate.Text;
            studentInfo[4]=joinDate.Text;
            studentInfo[5]=nationality.Text;

            try 
            {
                using (StreamWriter writer = new StreamWriter("ListOfStudents.txt", true))
                {
                    // Write each element of the array to the file separated by commas
                    writer.WriteLine(string.Join(",", studentInfo));
                }
                MessageBox.Show("Student registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button2Cancel_Click(object sender, EventArgs e)
        {
            Form1 objectForm1 = new Form1();
            objectForm1.Show();
            this.Hide();// close main form
        }
        private void ClearTextBoxes()
        {
            name.Clear();
            lastName.Clear();
            sponsorName.Clear();
            birthDate.Clear();
            joinDate.Clear();
            nationality.Clear();
        }
    }
}
