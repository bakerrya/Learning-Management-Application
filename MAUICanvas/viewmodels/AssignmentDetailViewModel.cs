using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUICanvas.viewmodels
{
    internal class AssignmentDetailViewModel : INotifyPropertyChanged
    {

        public Assignment assignment;
        public Course SelectedCourse { get; set; }
        public Assignment SelectedAssignment { get; set; }
        public ObservableCollection<Assignment> AssignmentList { get; private set; }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }

        public string Name {
            get => assignment?.Name ?? string.Empty;
            set { if (assignment != null) { assignment.Name = value; NotifyPropertyChanged(nameof(Name)); } }
        }
        public string Description {
            get => assignment?.Description ?? string.Empty;
            set { if (assignment != null) { assignment.Description = value; NotifyPropertyChanged(nameof(Description)); } }
        }
        public int TotalPoints {
            get => assignment?.TotalPoints ?? 0;
            set { if (assignment != null) { assignment.TotalPoints = value; NotifyPropertyChanged(nameof(TotalPoints)); } }
        }

        public DateTime DueDate {
            get => assignment?.DueDate ?? DateTime.Today;
            set { if (assignment != null) { assignment.DueDate = value; NotifyPropertyChanged(nameof(DueDate)); } }
        }

        public DateTime MinDate
        {
            get; private set;
        }

        public AssignmentDetailViewModel()
        {
            assignment = new Assignment();
            MinDate = DateTime.Today;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddAssignment(Shell s)
        {
            CourseService.Current.AddAssignment(assignment, SelectedCourse);
            s.GoToAsync("//Instructor");
        }

    }
}
