namespace MAUICanvas.views;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}