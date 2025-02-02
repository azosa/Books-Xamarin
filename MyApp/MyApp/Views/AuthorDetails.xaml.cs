﻿using MyApp.Model;
using MyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorDetails : ContentPage
    {
        public AuthorDetails(Author author)
        {
            InitializeComponent();
            BindingContext = new AuthorViewModel(author);
        }
    }
}