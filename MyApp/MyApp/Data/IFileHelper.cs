using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyApp.Data
{
    public interface IFileHelper
    {
        string GetLocalFilepath(string filename);
    }
}