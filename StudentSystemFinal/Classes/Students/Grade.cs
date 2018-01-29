using StudentSystemDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Students
{
    [Serializable]
    public class Grade
    {
        private int ID;
        private string assignmentName;
        private int pointsPossible;
        private double pointsEarned;

        public int TheID
        {
            get
            {
                return ID;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidStudentIDException("Invalid Assignment ID.");
                }
                else
                {
                    ID = value;
                }
            }
        }

        public string AssignmentName
        {
            get
            {
                return assignmentName;
            }
            set
            {
                if (value.Trim().Length == 0)
                {
                    throw new InvalidAssignmentNameException("Assignment Name can't be empty.");
                }
                else
                {
                    assignmentName = value;
                }
            }
        }
        
        public int PointsPossible
        {
            get
            {
                return pointsPossible;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidPointsPossibleException("Points possible must be greater than 0");
                }
                else
                {
                    pointsPossible = value;
                }
            }
        }

        public double PointsEarned
        {
            get
            {
                return pointsEarned;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidPointsEarnedException("Points earned can not be less than zero.");
                }
                else
                {
                    pointsEarned = value;
                }
            }
        }

        public double PercentageGrade
        {
            get
            {
                if (PointsPossible > 0 && PointsEarned >= 0)
                {
                    double hold = pointsEarned / PointsPossible;

                    hold = Math.Round(hold, 4) * 100;
                    return hold;
                }
                else
                {
                    if (PointsPossible <= 0)
                    {
                        throw new InvalidPointsPossibleException("Points possible must be greater than 0");
                    }

                    if (PointsEarned < 0)
                    {
                        throw new InvalidPointsEarnedException("Points earned can not be less than zero.");
                    }

                    return 0.0;
                }
            }
            private set { }
        }

        public string LetterGrade
        {
            get
            {
                string grade = "";

                var cases = new Dictionary<Func<double, bool>, Action>
                {
                    { z => z >= 97.00 , () => grade = "A+" } ,
                    { z => z >= 93.00 , () => grade = "A" } ,
                    { z => z >= 90.00 , () => grade = "A-" } ,
                    { z => z >= 87.00 , () => grade = "B+" } ,
                    { z => z >= 83.00 , () => grade = "B" } ,
                    { z => z >= 80.00 , () => grade = "B-" } ,
                    { z => z >= 77.00 , () => grade = "C+" } ,
                    { z => z >= 73.00 , () => grade = "C" } ,
                    { z => z >= 70.00 , () => grade = "C-" } ,
                    { z => z >= 67.00 , () => grade = "D+" } ,
                    { z => z >= 65.00 , () => grade = "D" } ,
                    { z => z < 65.00 ,  () => grade = "F" }
                };

                cases.First(kvp => kvp.Key(PercentageGrade)).Value();

                return grade;
            }
            private set { }
        }

        public Grade()
        {
            AssignmentName = "This is the Default";
            PointsPossible = 1;
            PointsEarned = 1;

            TheID = 0;
        }

        public Grade(string assignmentName, int pointsPossible, double pointsEarned)
        {
            AssignmentName = assignmentName;
            PointsPossible = pointsPossible;
            PointsEarned = pointsEarned;

            TheID = 0;
        }
    }
}
