using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUICanvas.viewmodels
{
    public class InstructorViewViewModel : INotifyPropertyChanged
    {
        public Person SelectedPerson {  get; set; }
        public Course SelectedCourse { get; set; }
        public bool IsEnrollmentsVisible {  get; set; }
        public bool IsCoursesVisible { get; set; }

        public InstructorViewViewModel()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
        }
        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }
        public void ShowCourses()
        {
            IsEnrollmentsVisible = false;
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }
        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }

        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(People));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void EditEnrollmentClick(Shell s)
        {
            var id = SelectedPerson?.id ?? 0;
            s.GoToAsync($"//StudentDetail?id={id}");
        }
        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//StudentDetail?id=0");
        }
        public void AddStudentToCourse(Shell s)
        {
            var courseName = SelectedCourse?.Name ?? string.Empty;
            s.GoToAsync($"//AddStudentView?courseName={courseName}");
        }

        public void AddCoursesClicked(Shell s)
        {
            s.GoToAsync("//CourseDetail");
        }
        public void AddContentToCourseClicked(Shell s)
        {
            var courseName = SelectedCourse?.Name ?? string.Empty;
            s.GoToAsync($"//ContentDetailView?courseName={courseName}");
        }
        public void AddAssignmentToCourseClicked(Shell s)
        {
            s.GoToAsync("//AssignmentDetail");
        }
        public void ViewAssignmentsForCourseClicked(Shell s)
        {
            var courseName = SelectedCourse?.Name ?? string.Empty;
            s.GoToAsync($"//AssignmentDetailForCourse?courseName={courseName}");
        }

        public void ViewModulesForCourseClicked(Shell s)
        {
            var courseName = SelectedCourse?.Name ?? string.Empty;
            s.GoToAsync($"//ContentDetailViewForCourse?courseName={courseName}");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }

        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }

        public void RemoveEnrollmentClicked()
        {
            if(SelectedPerson == null)
            {
                return;
            }
            StudentService.Current.Remove(SelectedPerson);
            RefreshView();
        }
    }
}
