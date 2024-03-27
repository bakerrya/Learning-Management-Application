
using Library.Canvas.Models;
using Library.Canvas.Services;
using MAUICanvas.viewmodels;
namespace MAUICanvas.views;

[QueryProperty(nameof(PersonId), "id")]
public partial class StudentDetailView : ContentPage
{
	public StudentDetailView()
	{
        InitializeComponent();
	}

    public int PersonId
    {
        get; set;
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDetailViewModel).AddPerson();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDetailViewModel(PersonId);
    }
}