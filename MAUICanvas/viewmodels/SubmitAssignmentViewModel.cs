using System;
using System.ComponentModel;
using Library.Canvas.database;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUICanvas.viewmodels
{
    internal class SubmitAssignmentViewModel : INotifyPropertyChanged
    {
        private string _textEntry;
        private DateTime _submissionTime;
        private Assignment _assignment;
        private AssignmentSubmission _submission;

        public string TextEntry
        {
            get => _textEntry;
            set
            {
                _textEntry = value;
                OnPropertyChanged(nameof(TextEntry));
            }
        }

        public DateTime SubmissionTime
        {
            get => _submissionTime;
            set
            {
                _submissionTime = value;
                OnPropertyChanged(nameof(SubmissionTime));
            }
        }

        public SubmitAssignmentViewModel(string assignmentName)
        {
            _assignment = CourseService.Current.GetAssignmentByName(assignmentName);
        }

        public void SubmitAssignment(Shell s)
        {
            if (_assignment != null && !string.IsNullOrEmpty(_textEntry))
            {
                _submission = new AssignmentSubmission(_textEntry, DateTime.Now);
                _assignment.Submissions.Add(_submission);
            }

            CourseService.Current.PrintSubmissionsForAssignment(_assignment.Name);
            s.GoToAsync("//StudentView");
        }

        public void ReturnClicked(Shell s)
        {
            s.GoToAsync("//MainPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
