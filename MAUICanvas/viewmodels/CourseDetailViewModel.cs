using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;


namespace MAUICanvas.viewmodels
{
    internal class CourseDetailViewModel
    {
        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }

        private Course course;

        private List<Person> studentsToEnroll = new List<Person>();


        public ObservableCollection<Person> EnrolledStudents
        {
            get
            {
                if (course != null)
                {
                    return new ObservableCollection<Person>(CourseService.Current.GetRosterForCourse(course));
                }
                else
                {
                    return new ObservableCollection<Person>();
                }
            }
        }

        public ObservableCollection<Person> NotEnrolledStudents
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }
        public string Name
        {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }

        public int Code
        {
            get => course?.Code ?? 0;
            set { if (course != null) course.Code = value; }
        }
        public int Id {  get; set; }

        public CourseDetailViewModel()
        {
            course = new Course();
        }

        public void AddCourse(Shell s)
        {

            CourseService.Current.Add(course);
            s.GoToAsync("//Instructor");

        }
        public void EnrollStudentsInCourse()
        {
            foreach (var student in studentsToEnroll)
            {
                CourseService.Current.AddStudent(student, course);
            }
            studentsToEnroll.Clear(); // Clear the list after enrollment
        }
        public void AddStudentToCourse(Shell s)
        {
            CourseService.Current.Add(course);
            EnrollStudentsInCourse();
            s.GoToAsync("//Instructor");
        }

        public void RemoveStudentFromCourse(Shell s) 
        {
            CourseService.Current.RemoveStudent(SelectedPerson, course);
            s.GoToAsync("//Instructor");
        }
        public void AddStudentToEnrollmentList()
        {
            studentsToEnroll.Add(SelectedPerson);
        }
    }
}
