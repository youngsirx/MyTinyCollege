namespace MyTinyCollege.Models


  
{  
            //grade enum

        public enum Grade
        {
            A, B, C, D, F
        }


    public class Enrollment
    {
        public int EnrollmentID { get; set; }//primary key

        public int CourseID { get; set; }//FK to course

        public int StudentID { get; set; }//FK to student

        public Grade? Grade { get; set; }//? in this case means optional

        public virtual Student student { get; set; }//many enrollments to 1 course

        public virtual Course course { get; set; }//many enrrollments to 1 course
    }


}