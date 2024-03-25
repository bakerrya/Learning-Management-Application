using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUICanvas.viewmodels
{
    public class InstructorViewViewModel : INotifyPropertyChanged
    {
        public Person SelectedPerson {  get; set; }
        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddClick(Shell s)
        {
            s.GoToAsync("//StudentDetail");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
        }

        public void RemoveClicked()
        {
            if(SelectedPerson == null)
            {
                return;
            }
            StudentService.Current.Remove(SelectedPerson);
            RefreshView();
        }
    }
}
