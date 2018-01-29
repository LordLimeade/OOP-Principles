using StudentSystemDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Students
{
    [Serializable]
    public class Student : IComparable
    {
        private string studentID;
        private string studentName;
        private List<Grade> grades = new List<Grade>();
        
        public string StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                if (value.Trim().Length != 7)
                {
                    throw new InvalidStudentIDException("ID must be seven characters long.");
                }
                else
                {
                    try
                    {
                        int hold = int.Parse(value);

                        studentID = value;
                    }
                    catch (Exception)
                    {
                        throw new InvalidStudentIDException("ID must be numeric.");
                    }
                }
            }
        }

        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                if (value.Trim().Length <= 0)
                {
                    throw new InvalidStudentNameException("Student name must have a value.");
                }
                else
                {
                    studentName = value;
                }
            }
        }

        public List<Grade> Grades
        {
            get
            {
                return grades;
            }
            set
            {
                grades = value;
            }
        }

        public int CompareTo(object obj)
        {
            Student hold = (Student)obj;

            string In = hold.studentID ;
            int InInt = 0, thisInt = 0;

            try
            {
                InInt = int.Parse(In);
                thisInt = int.Parse(this.StudentID);
            }
            catch (Exception)
            {
                throw new InvalidStudentIDException("Error converting Student ID");
            }

            return thisInt.CompareTo(InInt);
        }

        public Student()
        {
            StudentID = "1234567";
            StudentName = "Default";
        }

        public Student(string studentID, string studentName)
        {
            StudentID = studentID;
            StudentName = studentName;
        }
    }
}
