using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var log = entryLogin?.Text;
            var pass = entryPassword?.Text;

            if (await App.LocalDB.CheckIfUserExists(log, pass) == 1)
            {
        

                await Task.Delay(1000);

                Application.Current.MainPage = new NavigationPage(new Authors());
                return;
            }
            else
            {
                lblValidation.IsVisible = true;
                entryLogin.BackgroundColor = Color.OrangeRed;
                entryPassword.BackgroundColor = Color.OrangeRed;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            btnLogin.IsVisible = true;
            lblValidation.IsVisible = false;
            lblValidation2.IsVisible = false;
            entryLogin.BackgroundColor = Color.White;
            entryPassword.BackgroundColor = Color.White;
            entryLogin.Text = string.Empty;
            entryPassword.Text = string.Empty;
        }

        private void EntryLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            if (VerifyEntry(e.NewTextValue))
            {
                entry.BackgroundColor = Color.LightGreen;
            }
            else
            {
                entry.BackgroundColor = Color.LightGray;
            }

           
            btnRegister.IsEnabled = VerifyEntry(login.Text) && VerifyEntry(password.Text);

        }

        private bool VerifyEntry(string text)
        {
            return text != null && text.Length > 4;
        }


        
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            var log = login?.Text;
            var pass = password?.Text;
        
     

            if (await App.LocalDB.CheckIfUserExists(log, pass)==0)
            {
             

                var user = new User()
                {
                  Login =log,
                  Password = pass
                };
                lblValidation2.IsVisible = false;
                lblValidation3.IsVisible = true;
                entryLogin.BackgroundColor = Color.White;
                entryPassword.BackgroundColor = Color.White;
              
                await App.LocalDB.SaveItemAsync(user);
              
            }
            else
            {
                lblValidation3.IsVisible = false;
                lblValidation2.IsVisible = true;
                entryLogin.BackgroundColor = Color.OrangeRed;
                entryPassword.BackgroundColor = Color.OrangeRed;
            }
        }
       
    }
}
