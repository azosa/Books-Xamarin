using MyApp.Data;
using MyApp.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperDroid))]
namespace MyApp.Droid
{
    public class FileHelperDroid : IFileHelper
    {
        public string GetLocalFilepath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}