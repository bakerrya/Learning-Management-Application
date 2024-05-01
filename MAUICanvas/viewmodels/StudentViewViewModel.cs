using Library.Canvas.Models;
using Library.Canvas.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUICanvas.viewmodels
{
    internal class StudentViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Person> People { get; set; }
        public ObservableCollection<Course> Courses { get; set; }

        public bool IsStudentListVisible { get; set; }
        public bool IsCourseListVisible { get; set; }

        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }

        public StudentViewViewModel()
        {
            People = new ObservableCollection<Person>(StudentService.Current.Students);
            Courses = new ObservableCollection<Course>();
            IsStudentListVisible = true;
            IsCourseListVisible = false;
        }

        public void EnterStudentView(Shell s)
        {
            IsStudentListVisible = false;
            IsCourseListVisible = true;
            NotifyPropertyChanged(nameof(IsStudentListVisible));
            NotifyPropertyChanged(nameof(IsCourseListVisible));
            Courses.Clear();
            var courses = StudentService.Current.GetClasses(SelectedPerson);
            foreach (var course in courses)
            {
                Courses.Add(course);
            }
            NotifyPropertyChanged(nameof(Courses));
        }

        public void ViewAssignments(Shell s)
        {
            var courseName = SelectedCourse?.Name ?? string.Empty;
            s.GoToAsync($"//AssignmentDetailForCourse?courseName={courseName}");
        }
        public void ViewModules(Shell s)
        {
            var courseName = SelectedCourse?.Name ?? string.Empty;
            s.GoToAsync($"//ContentDetailViewForCourse?courseName={courseName}");
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
