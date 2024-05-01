using MAUICanvas.viewmodels;
namespace MAUICanvas.views;


[QueryProperty(nameof(SelectedCourse), "courseName")]
public partial class AddStudentView : ContentPage
{
    public string SelectedCourse { get; set; }
    public AddStudentView()
	{
		InitializeComponent();
	}
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
    private async void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddStudentViewModel(SelectedCourse);
    }
    private void EnrollInCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as AddStudentViewModel).EnrollStudentInCourse(Shell.Current);
    }


    private void ReturnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}