using Library.Canvas.Models;
using MAUICanvas.viewmodels;
namespace MAUICanvas.views;

public partial class CourseDetailView : ContentPage
{
	public CourseDetailView()
	{
		InitializeComponent();
		BindingContext = new CourseDetailViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddCourse(Shell.Current);
    }

    private void EnrollInCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).EnrollStudentInCourse(Shell.Current);
    }

    private void RemoveEnrollInCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).RemoveStudentFromCourse(Shell.Current);
    }

}