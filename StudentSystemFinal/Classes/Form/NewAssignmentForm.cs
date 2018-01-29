using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemDatabase;
using StudentSystemDatabase.Students;
using StudentSystemDatabase.Exceptions;

namespace StudentSystem
{
    public partial class NewAssignmentForm : Form
    {
        private List<object> students = new List<object>();
        private List<Grade> grades = new List<Grade>();
        public List<object> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (value.GetType() != typeof(List<object>))
                {
                    throw new Exception("Students must be a list of objects");
                }
                else
                {
                    foreach (object o in value)
                    {
                        if (false/*o.GetType() != typeof(Student) || o.GetType() != typeof(DormStudent)*/)
                        {
                            throw new Exception("List must only contain students and dorm students.");
                        }
                        else
                        {
                            students = value;
                        }
                    }
                }

            }
        }

        public List<Grade> Grades
        {
            get
            {
                return grades;
            }
            private set
            {

            }
        }

        public NewAssignmentForm()
        {
            InitializeComponent();
        }

        public NewAssignmentForm(List<object> students)
        {
            try
            {
                Students = students;
            }
            catch (Exception)
            {
                throw;
            }

            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ErrorList err = new ErrorList();

            err = CreateAssignment();

            if (err.hasErrors)
            {
                MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("Assignment Created", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AssignmentNameTxtBox.Text = "";
                PointsPossibleTxtBox.Text = "";

                ReturnBtn.Focus();
            }
        }

        private ErrorList ValidateData()
        {
            ErrorList err = new ErrorList();

            if (AssignmentNameTxtBox.Text.Trim().Length == 0)
            {
                err.Errors.Add("Assignment name must have a value.");
            }

            try
            {
                int hold = int.Parse(PointsPossibleTxtBox.Text);

                if (hold <= 0)
                {
                    err.Errors.Add("Points value must be greater than zero.");
                }
            }
            catch (Exception)
            {
                err.Errors.Add("Points value must be an integer.");
            }

            return err;
        }

        private ErrorList CreateAssignment()
        {
            ErrorList err = new ErrorList();
            Grade newAssignment = new Grade();

            err = ValidateData();

            if (err.hasErrors)
            {
                return err;
            }

            try
            {
                newAssignment = new Grade(AssignmentNameTxtBox.Text, int.Parse(PointsPossibleTxtBox.Text), 0);
            }
            catch (Exception ex)
            {
                err.Errors.Add(ex.Message);
            }

            if (err.hasErrors)
            {
                return err;
            }
            else
            {
                Grades.Add(newAssignment);
            }

            return err;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            AssignmentNameTxtBox.Text = "";
            PointsPossibleTxtBox.Text = "";

            AssignmentNameTxtBox.Focus();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PointsPossibleTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
