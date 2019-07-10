using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyApp.Model
{

  
        public class Book : ISqliteModel
        {
            [SQLite.AutoIncrement, SQLite.PrimaryKey]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Cover { get; set; }
            public DateTime PublicationDate { get; set; }
           
            public int AuthorId { get; set; }
        }
    

}