using System;
using System.Collections.Generic;
using Canvas.Helpers;
using Canvas.Models;
using Canvas.Services;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsvc = new StudentService();
            var coursesvc = new CourseService();
            var studenthelper = new StudentHelper(studentsvc);
            var coursehelper = new CourseHelper(studentsvc, coursesvc);
            var assignmenthelper = new AssignmentHelper(coursesvc);
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
                else if (result == 6){
                    coursehelper.SearchCourse();
                }
                else if (result == 7){
                    coursehelper.AddStudent();
                }
                else if (result == 8){
                    coursehelper.RemoveStudent();
                }
                else if (result == 9){
                    assignmenthelper.CreateAssignment();
                }
                

                displayMenu();
                int.TryParse(Console.ReadLine(),out result);
            }

        }

        static void displayMenu(){
            Console.WriteLine("Please select an option");
            Console.WriteLine("1: Create a new student");
            Console.WriteLine("2: Create a new course");
            Console.WriteLine("3: List all students");
            Console.WriteLine("4: List all courses");
            Console.WriteLine("5: Search for a student");
            Console.WriteLine("6: Search for a course");
            Console.WriteLine("7: Add a student to an existing course");
            Console.WriteLine("8: Remove student from existing course");
            Console.WriteLine("8: Add an assignment to an existing course");
            Console.WriteLine("10: Exit Program");

        }


    }
}
