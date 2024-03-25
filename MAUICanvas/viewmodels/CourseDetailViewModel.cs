using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;


namespace MAUICanvas.viewmodels
{
    internal class CourseDetailViewModel
    {

        private Course course;

        public string Name
        {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }

        public int CourseCode
        {
            get => course?.Code ?? 0;
        }
        public int Id {  get; set; }

        public CourseDetailViewModel()
        {
            course = new Course();
        }

        public void AddCourse(Shell s)
        {

            CourseService.Current.Add(course);
            s.GoToAsync("//Instructor");

        }
    }
}
