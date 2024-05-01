using MAUICanvas.viewmodels;
namespace MAUICanvas.views;

[QueryProperty(nameof(SelectedAssignment), "assignmentName")]
public partial class SubmitAssignmentView : ContentPage
{
    public string SelectedAssignment { get; set; }

    public SubmitAssignmentView()
	{
		InitializeComponent();
	}

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
    private async void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SubmitAssignmentViewModel(SelectedAssignment);
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as SubmitAssignmentViewModel).SubmitAssignment(Shell.Current);
    }

    private void ReturnClicked(object sender, EventArgs e)
    {
        (BindingContext as SubmitAssignmentViewModel).ReturnClicked(Shell.Current);
    }
}