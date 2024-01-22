using System;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Course and add it to a list of courses
            Console.WriteLine("Creating courses and adding to a list of courses ");
            List<Course> Courses = new List<Course>();
            Course math1011 = new Course(1011, "MATH1011", description: null, roster: null, assignments: null, modules: null);
            Course cop4530 = new Course(4530, "COP4530", description: null, roster: null, assignments: null, modules: null);
            Courses.Add(math1011);
            Courses.Add(cop4530);

            Console.WriteLine();
            Console.WriteLine("Displaying courses: ");
            foreach (var course in Courses)
            {
                course.DisplayCourseInfo();
            }
            Console.WriteLine();

            //Create a Student and add to a list of students and adding to a course roster
            Console.WriteLine("Creating students and adding to a list of students");
            List<Person> Students = new List<Person>();
            Person s1 = new Person("Marshall Mathers", Classification.freshman, 2.0);
            Person s2 = new Person("Ryan Baker", Classification.senior, 3.99);
            Students.Add(s1);
            Students.Add(s2);

            Console.WriteLine();
            Console.WriteLine("Adding students to Math1011 roster");
            Console.WriteLine();
            Console.WriteLine("Displaying a list of students:");
            foreach (var student in Students)
            {
                student.DisplayStudentInfo();
                math1011.Roster.Add(student);
            }

            Console.WriteLine();
            Console.WriteLine("Displaying students in Math1011 roster: ");
            foreach (var student in math1011.Roster)
            {
                student.DisplayStudentInfo();
            }
            Console.WriteLine();

            //Removing a student from Course Roster
            Console.WriteLine("Removing Marshall from MATH1011 roster and redisplaying roster");
            math1011.Roster.Remove(s1);
            foreach (var student in math1011.Roster)
            {
                student.DisplayStudentInfo();
            }




        }
    }
}