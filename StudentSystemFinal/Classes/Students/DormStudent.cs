using StudentSystemDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Students
{
    [Serializable]
    public class DormStudent : Student
    {
        private string dormLocation;
        private string mealPlan;

        public string DormLocation
        {
            get
            {
                return dormLocation;
            }
            set
            {
                if (value.Trim().Length <= 0)
                {
                    throw new InvalidDormLocationException("Dorm Location must have a value.");
                }
                else
                {
                    switch (value)
                    {
                        case ("Waffle"):
                            dormLocation = value;
                            break;
                        case ("Taco"):
                            dormLocation = value;
                            break;
                        case ("Pie"):
                            dormLocation = value;
                            break;
                        case ("Milkshake"):
                            dormLocation = value;
                            break;
                        case ("Hashbrown"):
                            dormLocation = value;
                            break;
                        case ("Fries"):
                            dormLocation = value;
                            break;
                        default:
                            throw new InvalidDormLocationException("Dorm Location was not a valid value.");
                    }
                }
            }
        }

        public string MealPlan
        {
            get
            {
                return mealPlan;
            }
            set
            {
                if (value.Trim().Length <= 0)
                {
                    throw new InvalidMealPlanException("Meal plan must have a value.");
                }
                else
                {
                    switch (value)
                    {
                        case ("B"):
                            mealPlan = value;
                            break;
                        case ("M"):
                            mealPlan = value;
                            break;
                        case ("H"):
                            mealPlan = value;
                            break;
                        default:
                            throw new InvalidMealPlanException("Meal plan was not a valid value.");
                    }
                }
            }
        }

        public DormStudent()
        {
            StudentID = "1234567";
            StudentName = "Default";
            DormLocation = "Waffle";
            MealPlan = "B";
        }

        public DormStudent(string studentID, string studentName, string dormLocation, string mealPlan)
        {
            StudentID = studentID;
            StudentName = studentName;
            DormLocation = dormLocation;
            MealPlan = mealPlan;
        }
    }
}
