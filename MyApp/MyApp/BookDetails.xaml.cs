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
	public partial class BookDetails : ContentPage
	{
        private Author _author;
        private Book _book;
		public BookDetails (Author author, Book book)
		{
            _author = author;
            _book = book;
			InitializeComponent ();

            lblId.Text = _book.Id.ToString();
            lblAuthor.Text = $"Author: {_author.FirstName} {_author.LastName}";
            entryTitle.Text = _book.Title;
            entryCover.Text = _book.Cover;
            pubDate.Date = _book.PublicationDate;
        }
        private async void Update_Clicked(object sender, EventArgs e)
        {
            _book.Title = entryTitle.Text;
            _book.Cover = entryCover.Text;
           
            _book.PublicationDate = pubDate.Date;

            await App.LocalDB.SaveItemAsync(_book);
            await Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Pytanie", "Czy na pewno usunąć książkę?", "TAK", "NIE"))
            {
           
                await App.LocalDB.DeleteItemAsync(_book);
                await Navigation.PopAsync();
            }
        }
    }
}