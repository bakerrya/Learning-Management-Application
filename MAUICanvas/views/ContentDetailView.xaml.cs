using MAUICanvas.viewmodels;

namespace MAUICanvas.views;


[QueryProperty(nameof(SelectedCourse), "courseName")]
public partial class ContentDetailView : ContentPage
{
    public string SelectedCourse { get; set; }
    public ContentDetailView()
	{
		InitializeComponent();
	}

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
    private async void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ContentDetailViewModel(SelectedCourse);
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ContentDetailViewModel).AddModule(Shell.Current);
    }
    private void ReturnClicked(object sender, EventArgs e)
    {
        (BindingContext as ContentDetailViewModel).ReturnClicked(Shell.Current);
    }
}