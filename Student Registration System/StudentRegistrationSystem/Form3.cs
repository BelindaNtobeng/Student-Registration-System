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
using System.Xml.Linq;

namespace StudentRegistrationSystem
{
    public partial class Form3 : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private List<string> studentInfo = new List<string>();
  
        private int i = 0;
        public Form3()
        {
            InitializeComponent();
            LoadStudentInfo();
            ShowStudentInfo();
            SaveStudentInfo();
        }
        private void LoadStudentInfo()
        {
            try
            {
                using (StreamReader reader = new StreamReader("ListOfStudents.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        studentInfo.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No student records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ShowStudentInfo()
        {
            if (i >= 0 && i < studentInfo.Count)
            {
                string[] studentData = studentInfo[i].Split(',');
                name.Text = studentData[0];
                lastName.Text = studentData[1];
                sponsorName.Text = studentData[2];
                textBox4.Text = studentData[3];
                textBox5.Text = studentData[4];
                textBox6.Text = studentData[5];
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                ShowStudentInfo();
            }
            else
            {
                MessageBox.Show("You are already at the first record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (i < studentInfo.Count - 1)
            {
                i++;
                ShowStudentInfo();
            }
            else
            {
                MessageBox.Show("You are already at the last record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nationality_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this student record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                studentInfo.RemoveAt(i);
                SaveStudentInfo();
                if (i >= studentInfo.Count)
                    i = studentInfo.Count - 1;
                ShowStudentInfo();
            }
        }
        private void SaveStudentInfo()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("ListOfStudents.txt", false))
                {
                    foreach (string studentInfo in studentInfo)
                    {
                        writer.WriteLine(studentInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 objectForm1 = new Form1();
            objectForm1.Show();
            this.Hide();// close main form
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
