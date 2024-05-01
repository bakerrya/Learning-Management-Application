using MAUICanvas.viewmodels;
namespace MAUICanvas.views;
public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
        BindingContext = new StudentViewViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewViewModel).EnterStudentView(Shell.Current);
    }
    private void ViewAssignmentsClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewViewModel).ViewAssignments(Shell.Current);
    }
    private void ViewModulesClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewViewModel).ViewModules(Shell.Current);
    }
}
