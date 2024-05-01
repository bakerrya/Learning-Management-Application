using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;
using MAUICanvas.viewmodels;
using Microsoft.Maui.Controls;

namespace MAUICanvas.views;

[QueryProperty(nameof(SelectedCourse), "courseName")]
public partial class AssignmentDetailForCourse : ContentPage
{
    public string SelectedCourse { get; set; }

    public AssignmentDetailForCourse()
    {
        InitializeComponent();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
    private async void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseAssignmentViewModel(SelectedCourse);
    }

    private void WorkOnAssignmentClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseAssignmentViewModel).WorkOnAssignmentClicked(Shell.Current);
    }

    private void ReturnClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseAssignmentViewModel).ReturnClicked(Shell.Current);
    }
}
