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
	public partial class Books : ContentPage
	{
        private Author _author;
		public Books (Author author)
		{
            _author = author;
            InitializeComponent ();
		}
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
           
            var book = (Book)e.Item;
            await Xamarin.Essentials.TextToSpeech.SpeakAsync($"Książka pod tytułem: {book.Title}, data publikacji: {book.PublicationDate.ToShortDateString()}");
            await Navigation.PushAsync(new BookDetails(_author,book));

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
            var title= entryTitle.Text;
            var cover = entryCover.Text;

            var publicationDate = pubDate.Date;

            var book = new Book()
            {
               Title = title,
               Cover= cover,
               PublicationDate = publicationDate,
                AuthorId = _author.Id
            };

            await App.LocalDB.SaveItemAsync(book);
            await RefreshList();
        }

        private async Task RefreshList()
        {
            var books = await App.LocalDB.GetBooksByAuthorId(_author.Id);
            lvBooks.ItemsSource = books;
        }
    }
}