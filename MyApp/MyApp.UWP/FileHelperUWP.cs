using MyApp.Data;
using MyApp.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.Storage;
using Xamarin.Forms;
[assembly: Dependency(typeof(FileHelperUWP))]
namespace MyApp.UWP
{
    public class FileHelperUWP : IFileHelper
    {
        public string GetLocalFilepath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}