using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Library.Canvas.Models;
using Library.Canvas.Services;
using Microsoft.Maui.Controls;

namespace MAUICanvas.viewmodels
{
    internal class AddAssignmentViewModel : INotifyPropertyChanged
    {
        private Course _course;

        public Person SelectedPerson { get; set; }

        public ObservableCollection<Person> EnrolledStudents { get; private set; }

        public ObservableCollection<Person> NotEnrolledStudents
        {
            get
            {
                var notEnrolledStudents = StudentService.Current.Students.Except(EnrolledStudents);
                return new ObservableCollection<Person>(notEnrolledStudents);
            }
        }

        public AddAssignmentViewModel(string courseName)
        {
            _course = CourseService.Current.GetCourseByName(courseName);
            EnrolledStudents = new ObservableCollection<Person>();
            LoadEnrolledStudents(); // Load initially enrolled students
        }

        public void EnrollStudentInCourse(Shell s)
        {
            CourseService.Current.AddStudent(SelectedPerson, _course);
            LoadEnrolledStudents(); // Reload enrolled students after enrollment
        }

        private void LoadEnrolledStudents()
        {
            var enrolledStudents = CourseService.Current.GetRosterForCourse(_course);
            EnrolledStudents.Clear();
            foreach (var student in enrolledStudents)
            {
                EnrolledStudents.Add(student);
            }
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
        }

        public void ReturnClicked(Shell s)
        {
            s.GoToAsync("//Instructor");
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
