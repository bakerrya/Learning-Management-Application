using MAUICanvas.viewmodels;
using Library.Canvas.Models;
namespace MAUICanvas.views;

public partial class AssignmentDetailView : ContentPage
{

    public Course SelectedCourse;
	public AssignmentDetailView()
	{
		InitializeComponent();
		BindingContext = new AssignmentDetailViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentDetailViewModel).AddAssignment(Shell.Current);
    }
}