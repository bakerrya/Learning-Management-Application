using System;
using System.Collections.Generic;

namespace Library.Canvas.Models
{
    public class Assignment
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int TotalPoints { get; set; }
        public DateTime DueDate { get; set; }
        public List<AssignmentSubmission> Submissions { get; set; }

        public Assignment()
        {
            Submissions = new List<AssignmentSubmission>();
        }

        public Assignment(string name, string? description, int totalPoints, DateTime dueDate)
            : this()
        {
            Name = name;
            Description = description;
            TotalPoints = totalPoints;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, TotalPoints: {TotalPoints}, Due Date: {DueDate}";
        }
    }

    public class AssignmentSubmission
    {
        public string TextEntry { get; set; }
        public DateTime SubmissionTime { get; set; }

        public AssignmentSubmission() { }

        public AssignmentSubmission(string textEntry, DateTime submissionTime)
        {
            TextEntry = textEntry;
            SubmissionTime = submissionTime;
        }

        public override string ToString()
        {
            return $"Text Entry: {TextEntry}, Submission Time: {SubmissionTime}";
        }
    }
}
