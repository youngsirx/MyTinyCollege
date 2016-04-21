using System.Collections.Generic;

namespace MyTinyCollege.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }//FK to department


        //======================navigation properties =======================

            //1 course to many enrollemnts
        public virtual ICollection<Enrollment> Enrollment { get; set; }

        //1 course to many intcrutors 
        public virtual ICollection<Instructor> Instrcutors { get; set; }

        //course belongs to a department
        public virtual Department Department { get; set; }

        public string CourseIdTitle
        {
            get
            {
                return CourseID + ", " + Title;
            }
        }

    }
}