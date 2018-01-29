using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystemDatabase.Students;
using StudentSystemDatabase;
using System.Data.OleDb;

namespace StudentSystemFinal.Classes
{
    public class Dependency
    {
        private static OleDbConnection conn;

        private static List<Student> currentStudents = new List<Student>();
        private static List<Student> newStudents = new List<Student>();
        private static List<Student> editStudents = new List<Student>();
        private static List<string> studentsToDelete = new List<string>();

        public static OleDbConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public static List<Student> CurrentStudents
        {
            get
            {
                return currentStudents;
            }
            set
            {
                if (value.GetType() != typeof(List<Student>))
                {
                    throw new Exception("Students must be a list of objects");
                }
                else
                {
                    foreach (object o in value)
                    {
                        if (o.GetType() != typeof(Student) && o.GetType() != typeof(DormStudent))
                        {
                            throw new Exception("List must only contain students and dorm students.");
                        }
                        else
                        {
                            currentStudents = value;
                        }
                    }
                }

            }
        }
        public static List<Student> NewStudents
        {
            //This is added to as the program progresses and changes are made.
            get
            {
                return newStudents;
            }
            private set
            {

            }
        }
        public static List<Student> EditStudents
        {
            //This is added to as the program progresses and changes are made.
            get
            {
                return editStudents;
            }
            private set
            {

            }
        }
        public static List<string> StudentsToDelete
        {
            get
            {
                return studentsToDelete;
            }
            private set
            {

            }
        }
    }
}
