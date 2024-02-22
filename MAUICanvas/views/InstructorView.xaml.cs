using MAUICanvas.viewmodels;
namespace MAUICanvas.views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

    private void AddPersonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDetail");
    }
}