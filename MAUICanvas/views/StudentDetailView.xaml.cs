namespace MAUICanvas.views;

using Library.Canvas.Models;
using Library.Canvas.Services;
using MAUICanvas.viewmodels;

public partial class StudentDetailView : ContentPage
{
	public StudentDetailView()
	{
        InitializeComponent();
		BindingContext = new StudentDetailViewModel();
	}

    private void SubmitClicked(object sender, EventArgs e)
    {
        var context = BindingContext as StudentDetailViewModel;
        Classification grade;

        if (context.ClassificationString == "Senior")
        {
            grade = Classification.Senior;
        }
        else if (context.ClassificationString == "Junior")
        {
            grade = Classification.Junior;
        }
        else if (context.ClassificationString == "Sophomore")
        {
            grade = Classification.Sophomore;
        }
        else
        {
            grade = Classification.Freshmen;
        }
        StudentService.Current.Add(new Person(context.Name, grade));
        Shell.Current.GoToAsync("//Instructor");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}