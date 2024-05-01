using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUICanvas.viewmodels
{
    internal class CourseDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Course _course;

        public ObservableCollection<Person> EnrolledStudents { get; private set; }

        public ObservableCollection<Person> NotEnrolledStudents
        {
            get
            {
                var notEnrolledStudents = StudentService.Current.Students.Except(EnrolledStudents);
                return new ObservableCollection<Person>(notEnrolledStudents);
            }
        }

        public string Name
        {
            get => _course?.Name ?? string.Empty;
            set { if (_course != null) { _course.Name = value; NotifyPropertyChanged(); } }
        }

        public string Description
        {
            get => _course?.Description ?? string.Empty;
            set { if (_course != null) { _course.Description = value; NotifyPropertyChanged(); } }
        }

        public int Code
        {
            get => _course?.Code ?? 0;
            set { if (_course != null) { _course.Code = value; NotifyPropertyChanged(); } }
        }

        public int Id { get; set; }

        public CourseDetailViewModel()
        {
            _course = new Course();
            EnrolledStudents = new ObservableCollection<Person>();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCourse(Shell s)
        {
            CourseService.Current.Add(_course); // Add the current course instance
            _course = new Course(); // Create a new instance for the next course
            s.GoToAsync("//Instructor");
        }

        public void EnrollStudentInCourse(Shell s)
        {
            CourseService.Current.AddStudent(SelectedPerson, _course);
            var updatedEnrolledStudents = CourseService.Current.GetRosterForCourse(_course);
            EnrolledStudents.Clear();
            foreach (var student in updatedEnrolledStudents)
            {
                EnrolledStudents.Add(student);
            }
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
        }

        public void RemoveStudentFromCourse(Shell s)
        {
            CourseService.Current.RemoveStudent(SelectedPerson, _course);
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
            s.GoToAsync("//Instructor");
        }

        public Person SelectedPerson { get; set; }
    }
}
