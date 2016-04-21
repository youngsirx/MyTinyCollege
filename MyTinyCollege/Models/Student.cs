using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTinyCollege.Models
{
    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }
        
        // 1 student with many enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        /*
         * within the entitiy framework, the enrollments property is a navigation property.
         * Navigation properites hold other entites that are related to this entity.
         * In this case, the enrrollments property of a student entity will hold all of the nrollment entitites 
         * that are related to that student entity.
         * 
         * in other words, if a given stuent row in a database has two related enrollment rows (PK - FK) that 
         * student entity's enrrollment navigation property will contain those two enrollment entities.
         * 
         */
    }
}