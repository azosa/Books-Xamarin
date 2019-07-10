using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
	public class AuthorViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged(nameof(LastName));
                }
            }
        }

        public int ID { get => _author.Id; }

        private Author _author;

        public Command SaveCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public AuthorViewModel(Author author)
        {
            _author = author;
            FirstName = _author.FirstName;
            LastName = _author.LastName;
            SaveCommand = new Command(async () => await SaveChanges());
            DeleteCommand = new Command(async () => await Delete());
        }

        private async Task Delete()
        {
            await App.LocalDB.DeleteItemAsync(_author);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task SaveChanges()
        {
            _author.FirstName = FirstName;
            _author.LastName = LastName;
            await App.LocalDB.SaveItemAsync(_author);
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
