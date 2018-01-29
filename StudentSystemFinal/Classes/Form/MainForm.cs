using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StudentSystemDatabase;
using StudentSystemDatabase.Students;
using StudentSystemDatabase.Exceptions;
using System.Linq;
using System.Data.OleDb;
using System.Data;
using StudentSystemFinal.Classes;

namespace StudentSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StudentsDropDown.Items.Add("Select a Student");
            StudentsDropDown.SelectedItem = "Select a Student";

            Dependency.CurrentStudents.Sort();

            foreach (Student s in Dependency.CurrentStudents)
            {
                StudentsDropDown.Items.Add(s.StudentID);
            }
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            AddEditStudentForm AESF = new AddEditStudentForm();

            var result = AESF.ShowDialog();

            StudentsDropDown.Items.Clear();

            StudentsDropDown.Items.Add("Select a Student");

            Dependency.CurrentStudents.Sort();

            foreach (Student s in Dependency.CurrentStudents)
            {
                StudentsDropDown.Items.Add(s.StudentID);
            }

            StudentsDropDown.SelectedItem = "Select a Student";
        }

        private void NewAssignmentBtn_Click(object sender, EventArgs e)
        {
            List<Grade> newAssignments = new List<Grade>();
            List<string> studentsEditted = new List<string>();
            NewAssignmentForm NAF = new NewAssignmentForm();

            var result = NAF.ShowDialog();

            StudentsDropDown.SelectedItem = "Select a Student";

            try
            {
                newAssignments = NAF.Grades;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving new assignments. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            foreach (Student s in Dependency.CurrentStudents)
            {
                studentsEditted.Add(s.StudentID);
                foreach (Grade g in newAssignments)
                {
                    int high = 0;

                    if (s.Grades.Any())
                    {
                        high = s.Grades.Max(a => a.TheID);
                    }

                    Grade hold = new Grade(g.AssignmentName, g.PointsPossible, g.PointsEarned);

                    hold.TheID = high + 1;

                    s.Grades.Add(hold);
                }
            }

            foreach (string s in studentsEditted)
            {
                if (Dependency.CurrentStudents.Any(a => a.StudentID == s))
                {
                    Student holdStu = Dependency.CurrentStudents.Where(a => a.StudentID == s).First();

                    Dependency.CurrentStudents.RemoveAll(a => a.StudentID == s);
                    Dependency.CurrentStudents.Add(holdStu);

                    if (Dependency.NewStudents.Any(a => a.StudentID == holdStu.StudentID))
                    {
                        Dependency.NewStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                        Dependency.NewStudents.Add(holdStu);
                    }
                    else
                    {
                        if (Dependency.EditStudents.Any(a => a.StudentID == holdStu.StudentID))
                        {
                            Dependency.EditStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                            Dependency.EditStudents.Add(holdStu);
                        }
                        else
                        {
                            Dependency.EditStudents.Add(holdStu);
                        }
                    }
                }
            }

            Dependency.CurrentStudents.Sort();
            Dependency.NewStudents.Sort();
            Dependency.EditStudents.Sort();
        }

        private void DeleteStudentBtn_Click(object sender, EventArgs e)
        {
            ErrorList err = new ErrorList();
            string compareID = StudentsDropDown.SelectedItem.ToString();
            if (compareID != "Select a Student")
            {
                if (MessageBox.Show("Are you sure you want to delete the student with ID: " + compareID, "Are Your Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    err = DeleteStudent(compareID);
                }
                else
                {
                    MessageBox.Show("Student not deleted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                err.Errors.Add("Please select a student to delete.");
            }



            if (err.hasErrors)
            {
                MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            StudentsDropDown.SelectedItem = "Select a Student";
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            ErrorList err = new ErrorList();
            List<string> allIDs = new List<string>();

            if (StudentsDropDown.Items.Count <= 1)
            {
                MessageBox.Show("There are no students to delete.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete all current students?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    foreach (object o in StudentsDropDown.Items)
                    {
                        allIDs.Add(o.ToString());
                    }

                    foreach (string s in allIDs)
                    {
                        if (s != "Select a Student")
                        {
                            var hold = DeleteStudent(s);

                            if (hold.hasErrors)
                            {
                                err.Errors = hold.Errors;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Students not deleted.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StudentsDropDown.SelectedItem = "Select a Student";
                }


                if (err.hasErrors)
                {
                    MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

                if (Dependency.CurrentStudents.Count() == 0 && Dependency.NewStudents.Count() == 0 && Dependency.EditStudents.Count() == 0)
                {
                    MessageBox.Show("Students deleted successfully.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StudentsDropDown.SelectedItem = "Select a Student";
                }
            }

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (MessageBox.Show("Would you like to save changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Write to Dataabase...
                    this.DialogResult = DialogResult.OK;

                    MessageBox.Show("Changes saved.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Changes not saved.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void StudentsDropDown_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(HiddenStudent.Text == "Select a Student" || HiddenStudent.Text == "") && HiddenStudent.Text != StudentsDropDown.SelectedItem.ToString())
            {
                MakeSaves(HiddenStudent.Text);
            }
            else
            {
                HiddenStudent.Text = StudentsDropDown.SelectedItem.ToString();
            }

            StudentDataGrid.Rows.Clear();

            object student = null;

            Student holdStu;
            DormStudent holdDormStu;

            if (StudentsDropDown.SelectedItem.ToString() == "Select a Student")
            {
                StuNameLabel.Text = "";
                StuDormLabel.Text = "";
                StuMealLabel.Text = "";
                StudentDataGrid.Enabled = false;
            }
            else
            {
                StudentDataGrid.Enabled = true;
                try
                {
                    student = Dependency.CurrentStudents.Where(a => a.StudentID == StudentsDropDown.SelectedItem.ToString()).First();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (student != null)
                {
                    if (student is Student && !(student is DormStudent))
                    {
                        holdStu = (Student)student;

                        StuNameLabel.Text = holdStu.StudentName;
                        StuDormLabel.Text = "N/A";
                        StuMealLabel.Text = "N/A";

                        foreach (Grade g in holdStu.Grades)
                        {
                            StudentDataGrid.Rows.Add(g.TheID, g.AssignmentName, g.PointsPossible, g.PointsEarned, String.Format("{0:00.00}%", g.PercentageGrade), g.LetterGrade);
                        }
                    }
                    else if (student is DormStudent)
                    {
                        holdDormStu = (DormStudent)student;

                        string mealPlan = "";

                        switch (holdDormStu.MealPlan)
                        {
                            case ("B"):
                                mealPlan = "B - Basic";
                                break;
                            case ("M"):
                                mealPlan = "M - Medium";
                                break;
                            case ("H"):
                                mealPlan = "H - High";
                                break;
                            default:
                                break;
                        }

                        StuNameLabel.Text = holdDormStu.StudentName;
                        StuDormLabel.Text = holdDormStu.DormLocation;
                        StuMealLabel.Text = mealPlan;

                        foreach (Grade g in holdDormStu.Grades)
                        {
                            StudentDataGrid.Rows.Add(g.TheID, g.AssignmentName, g.PointsPossible, g.PointsEarned, String.Format("{0:00.00}%", g.PercentageGrade), g.LetterGrade);
                        }
                    }
                }
            }
        }

        private void StudentDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (StudentsDropDown.SelectedItem.ToString() == "Select a Student")
            {
                MessageBox.Show("Please select a student before entering any grades.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveAssignmentBtn_Click(object sender, EventArgs e)
        {
            MakeSaves(HiddenStudent.Text);

            MessageBox.Show("Grades have been successfuly saved.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StudentsDropDown.SelectedItem = "Select a Student";
            StudentsDropDown.SelectedItem = HiddenStudent.Text;
        }

        private void DeleteAssignmentBtn_Click(object sender, EventArgs e)
        {
            List<int> workToDelete = new List<int>();

            if (StudentDataGrid.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select an assignment to delete.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (DataGridViewRow dr in StudentDataGrid.SelectedRows)
                {
                    var hold = dr.Cells[0].Value.ToString();
                    var student = Dependency.CurrentStudents.Where(a => a.StudentID == StudentsDropDown.SelectedItem.ToString());


                    try
                    {
                        workToDelete.Add(int.Parse(hold));
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error converting assignment ID.");
                    }

                    Student holdStu = student.First();

                    List<Grade> toRemove = new List<Grade>();

                    foreach (int x in workToDelete)
                    {
                        var thing = holdStu.Grades.Where(a => a.TheID == x);

                        if (thing.Count() > 0)
                        {
                            toRemove.Add(thing.First());
                        }
                    }

                    foreach (Grade g in toRemove)
                    {
                        holdStu.Grades.Remove(g);
                    }

                    StudentDataGrid.Rows.Clear();

                    foreach (Grade g in holdStu.Grades)
                    {
                        StudentDataGrid.Rows.Add(g.TheID, g.AssignmentName, g.PointsPossible, g.PointsEarned, String.Format("{0:##.00}%", g.PercentageGrade), g.LetterGrade);
                    }

                    if (Dependency.CurrentStudents.Any(a => a.StudentID == holdStu.StudentID))
                    {

                        Dependency.CurrentStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                        Dependency.CurrentStudents.Add(holdStu);

                        if (Dependency.NewStudents.Any(a => a.StudentID == holdStu.StudentID))
                        {
                            Dependency.NewStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                            Dependency.NewStudents.Add(holdStu);
                        }
                        else
                        {
                            if (Dependency.EditStudents.Any(a => a.StudentID == holdStu.StudentID))
                            {
                                Dependency.EditStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                                Dependency.EditStudents.Add(holdStu);
                            }
                            else
                            {
                                Dependency.EditStudents.Add(holdStu);
                            }
                        }
                    }

                    Dependency.CurrentStudents.Sort();
                    Dependency.NewStudents.Sort();
                    Dependency.EditStudents.Sort();

                }
            }
        }

        private ErrorList DeleteStudent(string ID)
        {
            ErrorList err = new ErrorList();
            List<Student> stuDelete = new List<Student>();

            Dependency.StudentsToDelete.Add(ID);

            if (Dependency.CurrentStudents.Any(a => a.StudentID == ID))
            {
                Dependency.CurrentStudents.RemoveAll(a => a.StudentID == ID);

                if (Dependency.NewStudents.Any(a => a.StudentID == ID))
                {
                    Dependency.NewStudents.RemoveAll(a => a.StudentID == ID);
                }
                else
                {
                    if (Dependency.EditStudents.Any(a => a.StudentID == ID))
                    {
                        Dependency.EditStudents.RemoveAll(a => a.StudentID == ID);
                    }
                }
            }
            else
            {
                err.Errors.Add("No student found with this ID: " + ID);
            }

            StudentsDropDown.Items.Remove(ID);
            return err;
        }

        private static void ValidateAssignment(int count, ErrorList err, List<string> values)
        {
            //Simple Event
            //Validates new Assignment Data

            if (values[0].Trim().Length <= 0)
            {
                err.Errors.Add("Assignment name must have a value. Row: " + count.ToString());
            }

            int thing = -1;
            int thingtwo = -1;

            try
            {
                thing = int.Parse(values[1]);
            }
            catch (Exception)
            {
                err.Errors.Add("Points possible must be numeric. Row: " + count.ToString());
            }

            try
            {
                thingtwo = int.Parse(values[2]);
            }
            catch (Exception)
            {
                err.Errors.Add("Points earned must be numeric. Row: " + count.ToString());
            }

            if (thing != -1)
            {
                if (thing == 0)
                {
                    err.Errors.Add("Points possible must be greater than zero. Row: " + count.ToString());
                }
            }

            if (thingtwo != -1)
            {
                if (thingtwo < 0)
                {
                    err.Errors.Add("Points earned must be zero or greater. Row: " + count.ToString());
                }
            }
        }

        private void MakeSaves(string compareID)
        {
            //string compareID = StudentsDropDown.SelectedItem.ToString();
            List<Grade> gradesToAdd = new List<Grade>();
            int count = 1;
            ErrorList err = new ErrorList();
            List<string> values = new List<string>(3);

            if (compareID == "Select a Student")
            {
                MessageBox.Show("Please select a student to edit their grades.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var hold = Dependency.CurrentStudents.Where(a => a.StudentID == compareID);
                Student holdStu = hold.First();

                foreach (DataGridViewRow r in StudentDataGrid.Rows)
                {
                    int currentErrors = err.Errors.Count();
                    values.Clear();

                    if (r.Index == StudentDataGrid.Rows.Count - 1)
                    {
                        //skip row
                    }
                    else
                    {
                        foreach (DataGridViewCell c in r.Cells)
                        {
                            if (!c.ReadOnly)
                            {
                                if (c.Value == null)
                                {
                                    values.Add("");
                                }
                                else
                                {
                                    values.Add(c.Value.ToString());
                                }
                            }
                        }

                        ValidateAssignment(count, err, values);

                        if (err.Errors.Count() <= currentErrors)
                        {
                            gradesToAdd.Add(new Grade(values[0], int.Parse(values[1]), int.Parse(values[2])));
                        }
                    }
                    count++;
                }

                if (err.hasErrors)
                {
                    MessageBox.Show(err.CompileErrors(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                holdStu.Grades.Clear();

                foreach (Grade g in gradesToAdd)
                {
                    int high = 0;

                    if (holdStu.Grades.Any())
                    {
                        high = holdStu.Grades.Max(a => a.TheID);
                    }

                    g.TheID = high + 1;

                    holdStu.Grades.Add(g);
                }


                Dependency.CurrentStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                Dependency.CurrentStudents.Add(holdStu);

                if (Dependency.NewStudents.Any(a => a.StudentID == holdStu.StudentID))
                {
                    Dependency.NewStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                    Dependency.NewStudents.Add(holdStu);

                    Dependency.NewStudents.Sort();
                }
                else
                {
                    if (Dependency.EditStudents.Any(a => a.StudentID == holdStu.StudentID))
                    {
                        Dependency.EditStudents.RemoveAll(a => a.StudentID == holdStu.StudentID);
                        Dependency.EditStudents.Add(holdStu);
                    }
                    else
                    {
                        Dependency.EditStudents.Add(holdStu);
                    }

                    Dependency.EditStudents.Sort();
                }
                Dependency.CurrentStudents.Sort();
            }
        }
    }
}
