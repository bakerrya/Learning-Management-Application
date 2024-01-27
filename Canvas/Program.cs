using System;
using System.Collections.Generic;
using Canvas.Helpers;
using Canvas.Models;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studenthelper = new StudentHelper();
            var coursehelper = new CourseHelper();
            displayMenu();
            int.TryParse(Console.ReadLine(),out int result);
            while(result != 10){
                if (result == 1){
                    studenthelper.CreateStudentRecord();
                }
                else if (result == 2){
                    coursehelper.CreateCourseRecord();
                }
                else if (result == 3){
                    studenthelper.ListStudents();
                }
                else if (result == 4){
                    coursehelper.ListCourses();
                }
                else if (result == 5){
                    studenthelper.SearchStudent();
                }


                displayMenu();
                int.TryParse(Console.ReadLine(),out result);
            }
            // //Create Course and add it to a list of courses
            // Console.WriteLine("Creating courses and adding to a list of courses ");
            // List<Course> Courses = new List<Course>();
            // Course math1011 = new Course(1011, "MATH1011", description: "Entry Level Math Class");
            // Course cop4530 = new Course(4530, "COP4530", description: "DSA");
            // Courses.Add(math1011);
            // Courses.Add(cop4530);

            // Console.WriteLine();
            // DisplayAllCourses(Courses);
            // Console.WriteLine();

            // //Create a Student and add to a list of students and adding to a course roster
            // Console.WriteLine("Creating students and adding to a list of students");
            // List<Person> Students = new List<Person>();
            // Person s1 = new Person("Marshall Mathers", Classification.freshman);
            // Person s2 = new Person("Ryan Baker", Classification.senior);
            // Students.Add(s1);
            // Students.Add(s2);

            // Console.WriteLine();
            // Console.WriteLine("Adding Marshall to Math1011 roster");
            // AddStudentToCourse(Students, math1011, s1);

            // Console.WriteLine();
            // Console.WriteLine("Displaying students in Math1011 roster: ");
            // foreach (var student in math1011.Roster)
            // {
            //     student.DisplayStudentInfo();
            // }
            // Console.WriteLine();
            // //Removing a student from Course Roster
            // Console.WriteLine("Removing Marshall from MATH1011 roster and redisplaying roster");
            // math1011.Roster.Remove(s1);
            // if (math1011.Roster.Any())
            // {
            //     foreach (var student in math1011.Roster)
            //     {
            //         student.DisplayStudentInfo();
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Roster is empty.");
            // }
            // Console.WriteLine();

            // //search for course by name
            // Console.WriteLine("Searching for course by name");
            // SearchForCourses(Courses, "MATH1011");
            // Console.WriteLine();
            // Console.WriteLine("Searching for course by Description");
            // SearchForCourses(Courses, "Entry Level Math Class");
            // Console.WriteLine();

            // //creating an assignment and adding it to a list of assignments
            // Console.WriteLine("Creating Assignment and adding it to math1011:");
            // DateTime aDate = new DateTime(2024, 1, 30, 12, 30, 0);
            // Assignment a1 = new Assignment("HW1", "Practice c#", 100, aDate);
            // math1011.Assignments.Add(a1);
            // Console.WriteLine("Displaying Assignments in Math1011:");
            // foreach (var a in math1011.Assignments){
            //     Console.WriteLine(a);
            // }
            // Console.WriteLine();

        }

        static void displayMenu(){
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1: Create a new student");
            Console.WriteLine("2: Create a new course");
            Console.WriteLine("3: List all students");
            Console.WriteLine("4: List all courses");
            Console.WriteLine("5: Search for a student: ");
            Console.WriteLine("6: Search for a course: ");
            Console.WriteLine("6: Remove student from existing course");
            Console.WriteLine("10: Exit Program");

        }

        static void AddStudentToCourse(List<Person> students, Course course, Person student)
        {
            foreach (var s in students)
            {
                if (s.Name == student.Name)
                {
                    course.Roster.Add(s);
                }
            }
        }


        //search by course name
        static void SearchForCourses(List<Course> courses, String NameOrDescription){
            foreach (var x in courses){
                if (x.Name == NameOrDescription || x.Description == NameOrDescription){
                    x.DisplayCourseInfo();
                }
            }
        }
    }
}
