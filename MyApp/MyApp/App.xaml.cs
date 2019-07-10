using MyApp.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyApp
{
    public partial class App : Application
    {
      

        private static LocalDatabase localDB;
        public static LocalDatabase LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var path = fileHelper.GetLocalFilepath("app.database");
                    localDB = new LocalDatabase(path);
                }

                return localDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
          
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
