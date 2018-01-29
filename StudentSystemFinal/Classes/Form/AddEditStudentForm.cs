using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using StudentSystemDatabase;
using StudentSystemDatabase.Students;
using StudentSystemDatabase.Exceptions;
using StudentSystemFinal.Classes;

namespace StudentSystem
{
    public partial class AddEditStudentForm : Form
    {
        public AddEditStudentForm()
        {
            //Simple Event
            //Initializes the form
            InitializeComponent();
        }
        
        private void AddEditStudentForm_Load(object sender, EventArgs e)
        {
            //Simple Event
            //Loads needed data into the form
            DormDropDown.Items.Add("Waffle");
            DormDropDown.Items.Add("Taco");
            DormDropDown.Items.Add("Pie");
            DormDropDown.Items.Add("Milkshake");
            DormDropDown.Items.Add("Hashbrown");
            DormDropDown.Items.Add("Fries");

            MealPlanCombo.Items.Add("B - Basic");
            MealPlanCombo.Items.Add("M - Medium");
            MealPlanCombo.Items.Add("H - High");

            Dependency.CurrentStudents.Sort();

            foreach (Student o in Dependency.CurrentStudents)
            {
                StudentsListBox.Items.Add(o.StudentID);
            }

            ResetForm();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            //Simple Event
            //Closes the form
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            //Simple Event
            //Calls the reset form method
            ResetForm();
        }

        private void NonDormRadio_CheckedChanged(object sender, EventArgs e)
        {
            //Simple Event
            //Enables or Disable form objects based on type of student
            if (DormRadio.Checked == true)
            {
                DormDropDown.Enabled = true;
                MealPlanCombo.Enabled = true;
            }
            else
            {
                DormDropDown.Enabled = false;
                MealPlanCombo.Enabled = false;

                DormDropDown.SelectedItem = "Waffle";
                MealPlanCombo.SelectedItem = "B - Basic";
            }
        }


        private void SaveStudentBtn_Click(object sender, EventArgs e)
        {
            //creates the new object and adds it to either the editted list or the new student list
            ErrorList err = new ErrorList();
            List<Grade> holdGrades = new List<Grade>();
            Student holdNewStu = null;
            DormStudent holdNewDormStu = null;
            bool newStudent = false;


            if (StudentsListBox.SelectedItem.ToString() == "New Student")
            {
                newStudent = true;
            }
            else
            {
                var hold = Dependency.CurrentStudents.Where(a => a.StudentID == StudentIDTextBox.Text);

                if (hold.Count() > 1)
                {
                    err.Errors.Add("Multiple Students found with the same ID.");
                }
                else if (hold.Count() < 1)
                {
                    err.Errors.Add("Error finding student with that ID.");
                    StudentsListBox.Items.Remove(StudentIDTextBox.Text);
                }
                else if (hold.Count() == 1)
                {
                    holdGrades = hold.First().Grades;
                }
            }
            

            if (err.hasErrors)
            {
                MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            

            //Change to validation command
            CheckStudentDataGood(err, holdGrades);

            if (err.hasErrors)
            {
                MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            
            try
            {
                if (NonDormRadio.Checked)
                {
                    holdNewStu = new Student(StudentIDTextBox.Text, NameTextBox.Text);
                    holdNewStu.Grades = holdGrades;
                }
                else
                {
                    string mealPlan = "";

                    switch (MealPlanCombo.SelectedItem)
                    {
                        case ("B - Basic"):
                            mealPlan = "B";
                            break;
                        case ("M - Medium"):
                            mealPlan = "M";
                            break;
                        case ("H - High"):
                            mealPlan = "H";
                            break;
                        default:
                            break;
                    }

                    holdNewDormStu = new DormStudent(StudentIDTextBox.Text, NameTextBox.Text, DormDropDown.SelectedItem.ToString(), mealPlan);
                    holdNewDormStu.Grades = holdGrades;
                }
            }
            catch (Exception ex)
            {
                err.Errors.Add(ex.Message);
            }
            

            if (err.hasErrors)
            {
                MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Student holdStu = null;

            if (DormRadio.Checked)
            {
                holdStu = holdNewDormStu;
            }
            else
            {
                holdStu = holdNewStu;
            }


            if (!newStudent)
            {
                Dependency.CurrentStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                Dependency.CurrentStudents.Add(holdStu);

                if (Dependency.EditStudents.Any(a => a.StudentID == holdStu.StudentID))
                {
                    Dependency.EditStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                    Dependency.EditStudents.Add(holdStu);
                }
                else
                {
                    Dependency.EditStudents.Add(holdStu);
                }

                Dependency.CurrentStudents.Sort();
                Dependency.EditStudents.Sort();
            }
            else
            {
                Dependency.CurrentStudents.Add(holdStu);
                Dependency.NewStudents.Add(holdStu);

                Dependency.CurrentStudents.Sort();
                Dependency.NewStudents.Sort();
            }
            
            ResetForm();
            ReturnBtn.Focus();
        }

        private void StudentsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            StudentIDTextBox.Enabled = true;
            ErrorList err = new ErrorList();

            if (StudentsListBox.SelectedItem.ToString() == "New Student")
            {
                StudentIDTextBox.Enabled = true;
                NonDormRadio.Checked = true;
                DormDropDown.Enabled = false;
                MealPlanCombo.Enabled = false;
                DormDropDown.SelectedItem = "Waffle";
                MealPlanCombo.SelectedItem = "B - Basic";
                StudentIDTextBox.Text = "";
                NameTextBox.Text = "";
            }
            else
            {
                //Need to search the current students list for that

                if (Dependency.CurrentStudents.Any(x => x.StudentID == StudentsListBox.SelectedItem.ToString()))
                {
                    try
                    {
                        var holdList = Dependency.CurrentStudents.Where(x => x.StudentID == StudentsListBox.SelectedItem.ToString());

                        if (holdList.Count() != 1)
                        {
                            if (holdList.Count() < 1)
                            {
                                throw new StudentIDNotFoundException("No student found with that ID.");
                            }
                            else if (holdList.Count() > 1)
                            {
                                throw new InvalidStudentIDException("Two students found with the same ID. Please contact IT immediately.");
                            }
                        }
                        else if(holdList.Count() == 1)
                        {
                            var hold = holdList.First();

                            if (hold is DormStudent)
                            {
                                DormStudent stu = (DormStudent)hold;

                                StudentIDTextBox.Enabled = false;
                                StudentIDTextBox.Text = stu.StudentID;
                                NameTextBox.Text = stu.StudentName;

                                DormRadio.Checked = true;
                                NonDormRadio.Checked = false;
                                DormDropDown.SelectedItem = stu.DormLocation;

                                switch (stu.MealPlan)
                                {
                                    case ("B"):
                                        MealPlanCombo.SelectedItem = "B - Basic";
                                        break;
                                    case ("M"):
                                        MealPlanCombo.SelectedItem = "M - Medium";
                                        break;
                                    case ("H"):
                                        MealPlanCombo.SelectedItem = "H - High";
                                        break;
                                    default:
                                        MealPlanCombo.SelectedItem = "B - Basic";
                                        break;
                                }
                            }
                            else if(hold is Student)
                            {
                                Student stu = (Student)hold;

                                StudentIDTextBox.Enabled = false;
                                StudentIDTextBox.Text = stu.StudentID;
                                NameTextBox.Text = stu.StudentName;

                                DormRadio.Checked = false;
                                NonDormRadio.Checked = true;
                                DormDropDown.SelectedItem = "Waffle";
                                MealPlanCombo.SelectedItem = "B - Basic";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        err.Errors.Add(ex.Message);
                    }
                }
            }
        }

        private void CheckStudentDataGood(ErrorList err, List<Grade> holdThis)
        {
            try
            {
                if (StudentIDTextBox.Text.Trim().Length == 0)
                {
                    throw new InvalidStudentIDException("Student ID must have a value.");
                }
                else if (StudentIDTextBox.Text.Trim().Length < 7)
                {
                    throw new InvalidStudentIDException("Student ID must be seven digits long.");
                }
                else
                {
                    try
                    {
                        int hold = int.Parse(StudentIDTextBox.Text);
                    }
                    catch (Exception)
                    {
                        throw new InvalidStudentIDException("Student ID must be numeric.");
                    }
                }
            }
            catch (InvalidStudentIDException ex)
            {
                err.Errors.Add(ex.Message);
            }

            if (err.hasErrors)
            {
                return;
            }
            

            if (StudentsListBox.SelectedItem.ToString() == "New Student")
            {
                try
                {
                    var hold = SearchForID(StudentIDTextBox.Text, holdThis);

                    if (hold != null)
                    {
                        throw new InvalidStudentIDException("There is already a student with that ID.");
                    }
                }
                catch (Exception ex)
                {
                    err.Errors.Add(ex.Message);
                }
            }
            else
            {
                try
                {
                    var hold = SearchForID(StudentIDTextBox.Text, holdThis);

                    if (hold == null)
                    {
                        throw new InvalidStudentIDException("Error editing that student.");
                    }
                    else if (hold != null)
                    {
                        if (hold.Count() != 1)
                        {
                            throw new Exception("Error editing dorm student.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    err.Errors.Add(ex.Message);
                }
            }


            try
            {
                if (NameTextBox.Text.Trim().Length <= 0)
                {
                    throw new InvalidStudentNameException("Student name must have a value.");
                }
            }
            catch (InvalidStudentNameException ex)
            {
                err.Errors.Add(ex.Message);
            }
        }

        private void ResetForm()
        {
            //Simple Event
            //Resets the form to base values

            StudentsListBox.Items.Clear();
            StudentsListBox.Items.Add("New Student");

            foreach (Student s in Dependency.CurrentStudents)
            {
                StudentsListBox.Items.Add(s.StudentID);
            }

            NonDormRadio.Checked = true;
            DormDropDown.Enabled = false;
            MealPlanCombo.Enabled = false;
            DormDropDown.SelectedItem = "Waffle";
            MealPlanCombo.SelectedItem = "B - Basic";
            StudentsListBox.SelectedItem = "New Student";
            StudentIDTextBox.Text = "";
            NameTextBox.Text = "";

            StudentsListBox.Focus();
        }

        private void StudentIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Simple Event
            //Ensures only numbers entered into the student ID
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private IEnumerable<Student> SearchForID(string searchID, List<Grade> holdThis)
        {
            if (Dependency.CurrentStudents.Any(a => a.StudentID == searchID))
            {
                var hold = Dependency.CurrentStudents.Where(a => a.StudentID == searchID);

                holdThis = hold.First().Grades;

                return hold;
            }

            return null;
        }
    }
}
