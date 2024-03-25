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
        (BindingContext as InstructorViewViewModel).AddClick(Shell.Current);
    }

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RefreshView();
	}

	private void RemovePersonClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RemoveClicked();
	}
	
}