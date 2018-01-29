using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystem;
using System.Data.OleDb;
using System.Data;
using StudentSystemDatabase.Students;
using StudentSystemFinal.Classes;

namespace StudentSystemFinal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dependency.Conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = StudentsSystem.accdb");

            DataSet ds = new DataSet();

            try
            {
                Dependency.Conn.Open();
                
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from Students", Dependency.Conn);
                da.Fill(ds, "Students");

                da = new OleDbDataAdapter("Select * from Grades", Dependency.Conn);
                da.Fill(ds, "Grades");
                
                Dependency.Conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error gathering data from the database. Please contact IT.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }

            //Loads data for forms to manipulate
            foreach (DataRow sdr in ds.Tables["Students"].Rows)
            {

                if ((bool)sdr["IsDormStu"])
                {
                    DormStudent stu = new DormStudent(sdr[0].ToString(), sdr["StudentName"].ToString(), sdr["DormLocation"].ToString(), sdr["MealPlan"].ToString());

                    foreach (DataRow gdr in ds.Tables["Grades"].Rows)
                    {
                        if (gdr[0].ToString() == stu.StudentID)
                        {
                            Grade holdGrade = new Grade(gdr["AssignName"].ToString(), int.Parse(gdr["PointsPossible"].ToString()), double.Parse(gdr["PointsEarned"].ToString()));
                            holdGrade.TheID = int.Parse(gdr[2].ToString());
                            stu.Grades.Add(holdGrade);
                        }

                    }

                    Dependency.CurrentStudents.Add(stu);
                }
                else
                {
                    Student stu = new Student(sdr[0].ToString(), sdr["StudentName"].ToString());

                    foreach (DataRow gdr in ds.Tables["Grades"].Rows)
                    {
                        if (gdr[0].ToString() == stu.StudentID)
                        {
                            Grade holdGrade = new Grade(gdr["AssignName"].ToString(), int.Parse(gdr["PointsPossible"].ToString()), double.Parse(gdr["PointsEarned"].ToString()));
                            holdGrade.TheID = int.Parse(gdr[2].ToString());
                            stu.Grades.Add(holdGrade);
                        }

                    }

                    Dependency.CurrentStudents.Add(stu);
                }
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainForm run = new MainForm();
            Application.Run(run);

            DialogResult result = run.DialogResult;

            if (result == DialogResult.OK)
            {
                SaveChanges();
            }
        }

        public static void SaveChanges()
        {
            try
            {
                Dependency.Conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                
                foreach (Student s in Dependency.EditStudents)
                {
                    if (s is Student && !(s is DormStudent))
                    {

                        //string alterStudentCmd = String.Format("UPDATE Students SET StudentName = '{0}', DormLocation = '{1}', MealPlan = '{2}', IsDormStu = {3} WHERE StuID = '{4}'", s.StudentName.Trim(), "", "", "FALSE", s.StudentID.Trim());
                        string alterStudentCmd = "UPDATE Students SET StudentName = @name, DormLocation = @dl, MealPlan = @ml, IsDormStu = @IDS WHERE StuID = @id";
                        da.UpdateCommand = new OleDbCommand(alterStudentCmd, Dependency.Conn);
                        
                        var nameParam = new OleDbParameter("name", OleDbType.VarWChar);
                        var dlParam = new OleDbParameter("dl", OleDbType.VarWChar);
                        var mlParam = new OleDbParameter("ml", OleDbType.VarWChar);
                        var IDSParam = new OleDbParameter("IDS", OleDbType.Boolean);
                        var idParam = new OleDbParameter("id", OleDbType.VarWChar);

                        nameParam.Value = s.StudentName.Trim();
                        dlParam.Value = "";
                        mlParam.Value = "";
                        IDSParam.Value = false;
                        idParam.Value = s.StudentID.Trim();

                        da.UpdateCommand.Parameters.Clear();
                        da.UpdateCommand.Parameters.Add(nameParam);
                        da.UpdateCommand.Parameters.Add(dlParam);
                        da.UpdateCommand.Parameters.Add(mlParam);
                        da.UpdateCommand.Parameters.Add(IDSParam);
                        da.UpdateCommand.Parameters.Add(idParam);

                        da.UpdateCommand.ExecuteNonQuery();
                    }
                    else if (s is DormStudent)
                    {
                        DormStudent hold = (DormStudent)s;

                        //string alterStudentCmd = String.Format("UPDATE Students SET StudentName = '{0}', DormLocation = '{1}', MealPlan = '{2}', IsDormStu = {3} WHERE StuID = '{4}'", s.StudentName.Trim(), hold.DormLocation.ToString().Trim(), hold.MealPlan.ToString().Trim(), "TRUE", s.StudentID.Trim());
                        string alterStudentCmd = "UPDATE Students SET StudentName = @name, DormLocation = @dl, MealPlan = @ml, IsDormStu = @IDS WHERE StuID = @id";
                        da.UpdateCommand = new OleDbCommand(alterStudentCmd, Dependency.Conn);
                        
                        var nameParam = new OleDbParameter("name", OleDbType.VarWChar);
                        var dlParam = new OleDbParameter("dl", OleDbType.VarWChar);
                        var mlParam = new OleDbParameter("ml", OleDbType.VarWChar);
                        var IDSParam = new OleDbParameter("IDS", OleDbType.Boolean);
                        var idParam = new OleDbParameter("id", OleDbType.VarWChar);
                        
                        nameParam.Value = s.StudentName.Trim();
                        dlParam.Value = hold.DormLocation.ToString().Trim();
                        mlParam.Value = hold.MealPlan.ToString().Trim();
                        IDSParam.Value = true;
                        idParam.Value = s.StudentID.Trim();

                        da.UpdateCommand.Parameters.Clear();
                        da.UpdateCommand.Parameters.Add(nameParam);
                        da.UpdateCommand.Parameters.Add(dlParam);
                        da.UpdateCommand.Parameters.Add(mlParam);
                        da.UpdateCommand.Parameters.Add(IDSParam);
                        da.UpdateCommand.Parameters.Add(idParam);

                        da.UpdateCommand.ExecuteNonQuery();
                    }

                    string deleteAssignmentsCmd = String.Format("DELETE FROM Grades WHERE StuID = '{0}'", s.StudentID);
                    da.DeleteCommand = new OleDbCommand(deleteAssignmentsCmd, Dependency.Conn);
                    da.DeleteCommand.ExecuteNonQuery();

                    
                    
                    foreach (Grade g in s.Grades)
                    {
                        //string insertAssignment = String.Format("INSERT INTO Grades VALUES ('{0}', '{1}', '{2}', {3}, {4})", s.StudentID.ToString().Trim(), g.AssignmentName.ToString().Trim(), g.TheID.ToString().Trim(), g.PointsPossible.ToString().Trim(), g.PointsEarned.ToString().Trim());
                        string insertAssignment = "INSERT INTO Grades VALUES (@stuID, @name, @id, @poss, @earn)";

                        da.InsertCommand = new OleDbCommand(insertAssignment, Dependency.Conn);

                        var stuIDParam = new OleDbParameter("id", OleDbType.VarWChar);
                        var nameParam = new OleDbParameter("name", OleDbType.VarWChar);
                        var idParam = new OleDbParameter("dl", OleDbType.VarWChar);
                        var possParam = new OleDbParameter("ml", OleDbType.Integer);
                        var earnParam = new OleDbParameter("IDS", OleDbType.Double);

                        stuIDParam.Value = s.StudentID.ToString().Trim();
                        nameParam.Value = g.AssignmentName.ToString().Trim();
                        idParam.Value = g.TheID.ToString().Trim();
                        possParam.Value = g.PointsPossible.ToString().Trim();
                        earnParam.Value = g.PointsEarned.ToString().Trim();

                        da.InsertCommand.Parameters.Clear();
                        da.InsertCommand.Parameters.Add(stuIDParam);
                        da.InsertCommand.Parameters.Add(nameParam);
                        da.InsertCommand.Parameters.Add(idParam);
                        da.InsertCommand.Parameters.Add(possParam);
                        da.InsertCommand.Parameters.Add(earnParam);

                        da.InsertCommand.ExecuteNonQuery();
                    }
                }

                foreach (Student s in Dependency.NewStudents)
                {
                    string selectCmd = "SELECT * FROM Students WHERE StuID = @id";
                    OleDbCommand command = new OleDbCommand(selectCmd, Dependency.Conn);

                    var idSearchParam = new OleDbParameter("id", OleDbType.VarWChar);
                    idSearchParam.Value = s.StudentID;

                    command.Parameters.Add(idSearchParam);

                    OleDbDataReader dr = command.ExecuteReader();
                    
                    if (dr.HasRows)
                    {
                        throw new Exception("Student is already in the database. Insert aborted.\n ID: " + s.StudentID);
                    }
                    else
                    {
                        if (s is Student && !(s is DormStudent))
                        {
                            string insertStudentCmd = "INSERT INTO Students VALUES (@id, @name, @dl, @ml, @IDS)";// s.StudentID.Trim(), s.StudentName.Trim(), "", "", "FALSE");

                            da.UpdateCommand = new OleDbCommand(insertStudentCmd, Dependency.Conn);
                            
                            var idParam = new OleDbParameter("id", OleDbType.VarWChar);
                            var nameParam = new OleDbParameter("name", OleDbType.VarWChar);
                            var dlParam = new OleDbParameter("dl", OleDbType.VarWChar);
                            var mlParam = new OleDbParameter("ml", OleDbType.VarWChar);
                            var IDSParam = new OleDbParameter("IDS", OleDbType.Boolean);

                            idParam.Value = s.StudentID.Trim();
                            nameParam.Value = s.StudentName.Trim();
                            dlParam.Value = "";
                            mlParam.Value = "";
                            IDSParam.Value = false;

                            da.UpdateCommand.Parameters.Add(idParam);
                            da.UpdateCommand.Parameters.Add(nameParam);
                            da.UpdateCommand.Parameters.Add(dlParam);
                            da.UpdateCommand.Parameters.Add(mlParam);
                            da.UpdateCommand.Parameters.Add(IDSParam);

                            da.UpdateCommand.ExecuteNonQuery();
                        }
                        else if (s is DormStudent)
                        {
                            DormStudent hold = (DormStudent)s;

                            //string insertStudentCmd = String.Format("INSERT INTO Students Values ('{0}', '{1}', '{2}', '{3}', {4})", s.StudentID.Trim(), s.StudentName.Trim(), hold.DormLocation.ToString().Trim(), hold.MealPlan.ToString().Trim(), "TRUE");
                            string insertStudentCmd = "INSERT INTO Students VALUES (@id, @name, @dl, @ml, @IDS)";// s.StudentID.Trim(), s.StudentName.Trim(), "", "", "FALSE");

                            da.UpdateCommand = new OleDbCommand(insertStudentCmd, Dependency.Conn);

                            var idParam = new OleDbParameter("id", OleDbType.VarWChar);
                            var nameParam = new OleDbParameter("name", OleDbType.VarWChar);
                            var dlParam = new OleDbParameter("dl", OleDbType.VarWChar);
                            var mlParam = new OleDbParameter("ml", OleDbType.VarWChar);
                            var IDSParam = new OleDbParameter("IDS", OleDbType.Boolean);
                            
                            idParam.Value = s.StudentID.Trim();
                            nameParam.Value = s.StudentName.Trim();
                            dlParam.Value = hold.DormLocation.ToString().Trim();
                            mlParam.Value = hold.MealPlan.ToString().Trim();
                            IDSParam.Value = false;

                            da.UpdateCommand.Parameters.Add(idParam);
                            da.UpdateCommand.Parameters.Add(nameParam);
                            da.UpdateCommand.Parameters.Add(dlParam);
                            da.UpdateCommand.Parameters.Add(mlParam);
                            da.UpdateCommand.Parameters.Add(IDSParam);

                            da.UpdateCommand.ExecuteNonQuery();
                        }

                        foreach (Grade g in s.Grades)
                        {
                            //string insertAssignment = String.Format("INSERT INTO Grades VALUES (@stuID, @name, @id, @poss, @earn)", s.StudentID.ToString().Trim(), g.AssignmentName.ToString().Trim(), g.TheID.ToString().Trim(), g.PointsPossible.ToString().Trim(), g.PointsEarned.ToString().Trim());
                            string insertAssignment = "INSERT INTO Grades VALUES (@stuID, @name, @id, @poss, @earn)";

                            da.InsertCommand = new OleDbCommand(insertAssignment, Dependency.Conn);

                            var stuIDParam = new OleDbParameter("id", OleDbType.VarWChar);
                            var nameParam = new OleDbParameter("name", OleDbType.VarWChar);
                            var idParam = new OleDbParameter("dl", OleDbType.VarWChar);
                            var possParam = new OleDbParameter("ml", OleDbType.Integer);
                            var earnParam = new OleDbParameter("IDS", OleDbType.Double);

                            stuIDParam.Value = s.StudentID.ToString().Trim();
                            nameParam.Value = g.AssignmentName.ToString().Trim();
                            idParam.Value = g.TheID.ToString().Trim();
                            possParam.Value = g.PointsPossible.ToString().Trim();
                            earnParam.Value = g.PointsEarned.ToString().Trim();

                            da.InsertCommand.Parameters.Clear();
                            da.InsertCommand.Parameters.Add(stuIDParam);
                            da.InsertCommand.Parameters.Add(nameParam);
                            da.InsertCommand.Parameters.Add(idParam);
                            da.InsertCommand.Parameters.Add(possParam);
                            da.InsertCommand.Parameters.Add(earnParam);

                            da.InsertCommand.ExecuteNonQuery();
                        }
                    }


                }

                foreach (string s in Dependency.StudentsToDelete)
                {
                    string deleteStudent = String.Format("DELETE FROM Students WHERE StuID = @id", s);
                    string deleteGrades = String.Format("DELETE FROM Grades WHERE StuID = @id", s);

                    var idStuParam = new OleDbParameter("id", OleDbType.VarWChar);
                    var idGradeParam = new OleDbParameter("id", OleDbType.VarWChar);

                    idStuParam.Value = s.Trim();
                    idGradeParam.Value = s.Trim();

                    da.DeleteCommand = new OleDbCommand(deleteStudent, Dependency.Conn);

                    da.DeleteCommand.Parameters.Clear();
                    da.DeleteCommand.Parameters.Add(idStuParam);
                    
                    da.DeleteCommand.ExecuteNonQuery();


                    da.DeleteCommand = new OleDbCommand(deleteGrades, Dependency.Conn);

                    da.DeleteCommand.Parameters.Clear();
                    da.DeleteCommand.Parameters.Add(idGradeParam);
                    
                    da.DeleteCommand.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                string hold = exc.Message;
            }

            Dependency.Conn.Close();
        }
    }
}
