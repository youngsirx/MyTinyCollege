namespace MyTinyCollege.Migrations.CollegeMigrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyTinyCollege.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyTinyCollege.Models.ApplicationDbContext";
        }

        protected override void Seed(MyTinyCollege.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //1. add some students
            var students = new List<Student>
            {
                new Student {FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2015-02-01"), Email = "calexander@tinycollege.com"},
                new Student {FirstName = "Alonse", LastName = "Arturo", EnrollmentDate = DateTime.Parse("2015-02-01"), Email = "aaturo@tinycollege.com"},
                new Student {FirstName = "John", LastName = "Smith", EnrollmentDate = DateTime.Parse("2015-02-01"), Email = "jsmith@tinycollege.com"},
                new Student {FirstName = "fadi", LastName = "faddior", EnrollmentDate = DateTime.Parse("2015-02-01"), Email = "ffaddior@tinycollege.com"},
                new Student {FirstName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2015-02-01"), Email = "lnorman@tinycollege.com"}
            };

            //loop each student and add to database (only if they are nto already present)
            //using the addorupdate method
            //the first parameter of this method specifies the property to check if a row already exists.

            students.ForEach(s => context.Students.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();


            //2. add some instructors
            var instructors = new List<Instructor>
            {
                new Instructor {FirstName="jordan",
                                LastName="young",
                                HireDate=DateTime.Parse("2015-09-01"),
                                Email="jyoung@faculty.tinycollege.com"},

                new Instructor {FirstName="frank",
                                LastName="bekkering",
                                HireDate=DateTime.Parse("2015-09-01"),
                                Email="fbekkering@faculty.tinycollege.com"}

            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            //3. add some departments
            var departments = new List<Department>
            {
                new Department {Name="Engineering", Budget = 350000,
                                StartDate=DateTime.Parse("2010-09-01"),
                                InstructorID=1},
               new Department {Name="english", Budget = 150000,
                                StartDate=DateTime.Parse("2010-09-01"),
                                InstructorID=2},
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();




            //4 add some courses
            var courses = new List<Course>
                {
                    new Course {CourseID = 1045, Title="Chemistry", Credits = 3, DepartmentID = 1},
                    new Course {CourseID = 4022, Title="Physics", Credits = 3,  DepartmentID = 1 },
                    new Course {CourseID = 3141, Title="Calculus", Credits = 3, DepartmentID=1 },
                    new Course {CourseID = 2021, Title="Literature", Credits = 3,  DepartmentID = 2 },
                };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();



            //5. add some enrollments
            var enrollments = new List<Enrollment>
            {
                new Enrollment {StudentID =1, CourseID=1045, Grade=Grade.A ,  },
                new Enrollment {StudentID =1, CourseID=4022, Grade=Grade.B },
                new Enrollment {StudentID =2, CourseID=3141, Grade=Grade.C },
                new Enrollment {StudentID =2, CourseID=1045, Grade=Grade.B },
                new Enrollment {StudentID =3, CourseID=2021, Grade=Grade.B },
                new Enrollment {StudentID =3, CourseID=3141, Grade=Grade.A },
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDatabase = context.Enrollments.Where(
                    s =>
                    s.StudentID == e.StudentID &&
                    s.course.CourseID == e.CourseID).SingleOrDefault();

                //SingleOrDefault: returns a single, specific emelent of a sequence, or a default value if no such element is found.

                //use this when expecting a 0 or 1 item
                // you get 0 when 0 or 1 expected (ok)
                //you get 1 when 0 or 1 expected (ok)
                // you get 2 or more when 0 or 1 was expected (error)


                //single: return a single, specific element of a sequence
                //use when 1 item expected (not 0 or 2 and more)
                //

                if (enrollmentInDatabase == null)
                {
                    //enrollment was not foudn - add it ot db context
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();


        }
    }
}
