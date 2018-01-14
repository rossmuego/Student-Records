using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Student
    {
        //  Declaring the variables for the student class
        //  that are set using the getters and setters below.

        private int matricNo;
        private string forename;
        private string surname;
        private double courseworkMark;
        private double examMark;
        private DateTime dob;

        //  The getters and setters for the student class.
        //  There is validation in the setters to check that 
        //  the inputs are valid. If they are not an exception is 
        //  thrown and caught in the main method. 
        public int Matric
        {
            get { return matricNo; }
            set { matricNo = value; }
            
        }

        public string Forename
        {
           get
           {
                return forename;
           }
           set
           {
                //  Checking that the value being assigned to forename
                //  is not left blank, otherwise thrown an exception

                if (value != "")
                {
                    forename = value;
                } else
                {
                    throw new ArgumentException("Must enter forename");
                }
           }
        }

        public string Surname
        {
            get
            {
               return surname;
            }
            set
            {
                //  Checking that the value being assigned to surname is not 
                //  blank otherwise throwing an exception.

                if (value != "")
                {
                    surname = value;
                }
                else
                {
                    throw new ArgumentException("Must enter surname");
                }
            }
        }

        public double CourseworkMark
        {
            get
            {
                return courseworkMark;
            }
            set
            {
                //  Checking that the coursework mark is between 0 
                //  and 20 and that it is not left blank otherwise
                //  throw an exception.

                if(value < 0 || value > 20 || value.ToString() == null)
                {
                    throw new ArgumentException("Coursework result has to be between 0 and 20");
                } else
                {
                    courseworkMark = value;
                }
            }
        }

        public double ExamMark
        {
            get
            {
                return examMark;
            }
            set
            {
                //  Checking that the exam mark is between 0 and 40 and 
                //  that it is not left blank, if it is then throwing an
                //  exception.

                if(value < 0 || value > 40 || value.ToString() == null)
                {
                    throw new ArgumentException("Exam mark must be between 0 and 40");
                }
                else
                {
                    examMark = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dob;
            }
            set
            {
                //  checking that the date of birth entered is not
                //  left blank and if it is throwing an exception.
                if (value != null)
                {
                    dob = value;
                }
                else
                {
                    throw new ArgumentException("Must enter a DOB");
                }
            }
        }

        //  This is the constructor returning the final calculated
        //  mark. Returned is the final mark calculated by multiplying
        //  the coursework mark and exam mark and adding them together.
        public double getMark
        {
            get
            {
                double courseworkPercent = courseworkMark * 2.5;
                double examPercent = examMark * 1.25;

                double totalPercent = courseworkPercent + examPercent;

                return totalPercent;
            }
        }

    }
}
