using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyApp.Model
{


    public class User : ISqliteModel
    {
        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }


}