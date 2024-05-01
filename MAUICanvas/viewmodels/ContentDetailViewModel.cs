using Library.Canvas.Models;
using Library.Canvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUICanvas.viewmodels
{
    class ContentDetailViewModel : INotifyPropertyChanged
    {

        public string CourseName { get; set; }

        public ObservableCollection<Module> Modules { get; private set; } = new ObservableCollection<Module>();
        public Module module { get; set; }
        public string Name
        {
            get => module?.Name ?? string.Empty;
            set { if (module != null) { module.Name = value; NotifyPropertyChanged(nameof(Name)); } }
        }
        public string Description
        {
            get => module?.Name ?? string.Empty;
            set { if (module != null) { module.Name = value; NotifyPropertyChanged(nameof(Description)); } }
        }

        public ContentDetailViewModel(string courseName)
        {
            this.CourseName = courseName;
            module = new Module();
            FetchModules();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void FetchModules()
        {
            var modules = CourseService.Current.GetModulesForCourse(CourseName);
            Modules.Clear();
            foreach (var module in modules)
            {
                Modules.Add(module);
            }
        }

        public void AddModule(Shell s)
        {
            if (module != null)
            {
                CourseService.Current.AddModule(module, CourseName);
            }
            s.GoToAsync("//Instructor");
        }

        public void ReturnClicked(Shell s)
        {
            s.GoToAsync("//Instructor");
        }
    }
}
