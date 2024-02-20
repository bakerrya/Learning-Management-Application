using Library.Canvas.Models;
using Library.Canvas.Services;

namespace Canvas.Helpers {
    internal class CourseHelper{

        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper(StudentService ssrvc, CourseService csrvc){
            studentService = ssrvc;
            courseService = csrvc;

        }
        public void CreateCourseRecord(Course? selectedCourse = null){
            Console.WriteLine("Please enter in the course code: ");
            int.TryParse(Console.ReadLine(), out var code);
            Console.WriteLine("Please enter in the name of the course: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter an optional description: ");
            var description = Console.ReadLine();
            
            if (selectedCourse == null){
                var course = new Course(code, name ?? string.Empty, description ?? string.Empty);
                courseService.Add(course);
                courseService.courseList.ForEach(Console.WriteLine);
                Console.WriteLine();
                return;
            }
            selectedCourse.Code = code;
            selectedCourse.Name = name;
            selectedCourse.Description = description;

            courseService.courseList.ForEach(Console.WriteLine);
            Console.WriteLine();

        }


        public void RemoveStudent()
        {
            Console.WriteLine("Please enter in the student name you would like to remove: ");
            var studentName = Console.ReadLine();
            Person selectedStudent;

            if (studentName != null)
            {
                selectedStudent = studentService.studentList.FirstOrDefault(s => s.Name == studentName);
                if (selectedStudent == null){
                    Console.WriteLine("No such student found");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid Entry");
                return;
            }

            Console.WriteLine("Please enter in the course you would like to remove the student from: ");
            var courseName = Console.ReadLine();
            Course selectedCourse;

            if (courseName != null)
            {
                selectedCourse = courseService.courseList.FirstOrDefault(s => s.Name == courseName);
                if (selectedCourse == null){
                    Console.WriteLine("No such course found");
                    Console.WriteLine();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine();
                return;
            }

            courseService.RemoveStudent(selectedStudent, selectedCourse);
            Console.WriteLine($"Student '{studentName}' removed from course '{courseName}'");
            Console.WriteLine();
        }
        public void AddStudent()
        {
            Console.WriteLine("List of Students:");
            studentService.studentList.ForEach(Console.WriteLine);
            Console.WriteLine("Please enter the student name you would like to add: ");
            var studentName = Console.ReadLine();
            Person existingStudent;

            if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Invalid Entry");
                return;
            }

            // Check if the student with the same name already exists
            existingStudent = studentService.studentList.FirstOrDefault(s => s.Name == studentName);
            if (existingStudent == null)
            {
                Console.WriteLine("Student not found in the list. Cannot add to a course.");
                return;
            }

            Console.WriteLine("Please enter the course where you would like to add the student: ");
            var courseName = Console.ReadLine();
            Course selectedCourse;

            if (string.IsNullOrWhiteSpace(courseName))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine();
                return;
            }

            // Check if the course exists
            selectedCourse = courseService.courseList.FirstOrDefault(s => s.Name == courseName);
            if (selectedCourse == null)
            {
                Console.WriteLine("No such course found");
                Console.WriteLine();
                return;
            }

            // Add the existing student to the course
            courseService.AddStudent(existingStudent, selectedCourse);

            Console.WriteLine($"Student '{studentName}' added to course '{courseName}'");
            Console.WriteLine();
        }

        public void updateCourse(){
            Console.WriteLine("Please select a course to update: ");
            courseService.courseList.ForEach(Console.WriteLine);
            var desiredCourse = Console.ReadLine();

            Course selectedCourse = courseService.courseList.FirstOrDefault(c => c.Name == desiredCourse);

            if (selectedCourse == null){
                Console.WriteLine("No such course found");
                Console.WriteLine();
                return;
            }
            
            CreateCourseRecord(selectedCourse);

        }

        public void SearchCourse(){
            Console.WriteLine("Please enter in course name: ");
            var query = Console.ReadLine() ?? string.Empty;
            courseService.SearchCourse(query).ToList().ForEach(Console.WriteLine);
        }
        public void ListCourses(){
            courseService.ListCourses();
        }
    }
}