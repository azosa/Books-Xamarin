using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Authors : ContentPage
	{
		public Authors ()
		{
			InitializeComponent ();
		}
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var author = (Author)e.Item;


            await Xamarin.Essentials.TextToSpeech.SpeakAsync($"Autor: {author.FirstName} {author.LastName}");

 

            if (await DisplayAlert("Czy chcesz edytować autora?", $"Autor: {author.FirstName} {author.LastName}", "TAK", "Nie, przejdź do książek"))
            {
                await Navigation.PushAsync(new Views.AuthorDetails(author));
                
            }
            else
            {
                await Navigation.PushAsync(new Books(author));
              
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshList();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            var lastName = entryLastName.Text;

            var author = new Author()
            {
                FirstName = firstName,
                LastName = lastName
            };

            await App.LocalDB.SaveItemAsync(author);
            await RefreshList();
        }

        private async Task RefreshList()
        {
            var authors = await App.LocalDB.GetItemsAsync<Author>();
            lvAuthors.ItemsSource = authors;
        }
    }
}