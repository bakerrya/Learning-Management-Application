using Library.Canvas.Models;
using Library.Canvas.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUICanvas.viewmodels
{
    internal class StudentDetailViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public StudentDetailViewModel(int id = 0)
        {   
            if (id > 0){
                LoadById(id);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = StudentService.Current.GetById(id) as Person;
            if (person != null)
            {
                Name = person.Name;
                Id = person.id;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationString));

        }

        public void AddPerson()
        {

            if (Id <= 0)
            {
                StudentService.Current.Add(new Person(Name, StringToClass(ClassificationString)));
            }
            else
            {
                var refToUpdate = StudentService.Current.GetById(Id) as Person;
                refToUpdate.Name = Name;
                refToUpdate.Classification = StringToClass(ClassificationString);
            }
            Shell.Current.GoToAsync("//Instructor");
        }

        private Classification StringToClass(string s)
        {
            Classification classification;
            switch (s)
            {
                case "Senior":
                    classification = Classification.Senior;
                    break;
                case "Junior":
                    classification = Classification.Junior;
                    break;
                case "Sophomore":
                    classification = Classification.Sophomore;
                    break;
                case "Freshmen":
                default:
                    classification = Classification.Freshmen;
                    break;
            }

            return classification;
        }

        private string ClassToString(Classification pc)
        {
            var classificationString = string.Empty;
            switch (pc)
            {
                case Classification.Senior:
                    classificationString = "Senior";
                    break;
                case Classification.Junior:
                    classificationString = "Junior";
                    break;
                case Classification.Sophomore:
                    classificationString = "Sophomore";
                    break;
                case Classification.Freshmen:
                default:
                    classificationString = "Freshmen";
                    break;
            }
            return classificationString;
        }

    }
}
