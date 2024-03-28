using System;
using System.Collections.Generic;
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

        public Person SelectedPerson { get; set; }

        private Course course;

        public ObservableCollection<Person> EnrolledStudents => new ObservableCollection<Person>(CourseService.Current.GetRosterForCourse(course));

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
            get => course?.Name ?? string.Empty;
            set { if (course != null) { course.Name = value; NotifyPropertyChanged(nameof(Name)); } }
        }

        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) { course.Description = value; NotifyPropertyChanged(nameof(Description)); } }
        }

        public int Code
        {
            get => course?.Code ?? 0;
            set { if (course != null) { course.Code = value; NotifyPropertyChanged(nameof(Code)); } }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Id { get; set; }

        public CourseDetailViewModel()
        {
            course = new Course();
        }

        public void AddCourse(Shell s)
        {
            CourseService.Current.Add(course);
            s.GoToAsync("//Instructor");
        }

        public void EnrollStudentInCourse(Shell s)
        {
            CourseService.Current.AddStudent(SelectedPerson, course);
            // Clear the existing collection
            EnrolledStudents.Clear();

            // Repopulate the collection with the updated data
            var updatedEnrolledStudents = CourseService.Current.GetRosterForCourse(course);
            foreach (var student in updatedEnrolledStudents)
            {
                EnrolledStudents.Add(student);
            }
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
        }

        public void RemoveStudentFromCourse(Shell s)
        {
            CourseService.Current.RemoveStudent(SelectedPerson, course);
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
            s.GoToAsync("//Instructor");
        }


    }
}
