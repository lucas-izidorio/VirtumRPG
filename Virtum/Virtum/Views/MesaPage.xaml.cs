
﻿using Virtum.ViewModels;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtum.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MesaPage : ContentPage
    {
        public MesaViewModel ViewModel;

        public MesaPage(Reino reino)
        {
            InitializeComponent();
            ViewModel = new MesaViewModel(Navigation, reino);
            BindingContext = ViewModel;
        }
    }
}