using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUICanvas.viewmodels
{
    public class CourseAssignmentViewModel : INotifyPropertyChanged
    {
        public string CourseName { get; set; }

        public CourseAssignmentViewModel(string courseName)
        {
            this.CourseName = courseName;
            Assignments = new ObservableCollection<Assignment>();
            FetchAssignments();
        }

        public void FetchAssignments()
        {
            var assignments = CourseService.Current.GetAssignmentsForCourse(CourseName);

            Assignments.Clear();
            foreach (var assignment in assignments)
            {
                Assignments.Add(assignment);
            }
        }

        public ObservableCollection<Assignment> Assignments { get; private set; }

        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ReturnClicked(Shell s)
        {
            s.GoToAsync("//Instructor");
        }
    }
}