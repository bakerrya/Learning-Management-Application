using Library.Canvas.Models;
using Library.Canvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUICanvas.viewmodels
{
    internal class StudentViewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _people;
        private ObservableCollection<Course> _courses;
        private bool _isStudentListVisible;
        private bool _isCourseListVisible;

        public event PropertyChangedEventHandler PropertyChanged;

        public StudentViewViewModel()
        {
            // Initialize collections
            _people = new ObservableCollection<Person>(StudentService.Current.Students);
            _courses = new ObservableCollection<Course>();
            _isStudentListVisible = true;
            _isCourseListVisible = false;
        }

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                if (_people != value)
                {
                    _people = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsStudentListVisible
        {
            get { return _isStudentListVisible; }
            set
            {
                if (_isStudentListVisible != value)
                {
                    _isStudentListVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool IsCourseListVisible
        {
            get { return _isCourseListVisible; }
            set
            {
                if (_isCourseListVisible != value)
                {
                    _isCourseListVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Person SelectedPerson { get; set; }

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


        public void ViewAssignments()
        {
            // Implementation for viewing assignments
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
