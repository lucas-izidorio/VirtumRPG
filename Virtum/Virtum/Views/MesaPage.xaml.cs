<<<<<<< HEAD
﻿using Virtum.ViewModels;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtum.Models;
using Virtum.ViewModels;
>>>>>>> e237bc39cb90cf7a3cfb3178e1b1779421990658
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MesaPage : ContentPage
    {
<<<<<<< HEAD
        public MesaViewModel ViewModel;

        public MesaPage()
        {
            InitializeComponent();
            ViewModel = new MesaViewModel(Navigation);
=======
        MesaViewModel ViewModel;
        public MesaPage(Reino reino)
        {
            InitializeComponent();
            ViewModel = new MesaViewModel(Navigation, reino);
>>>>>>> e237bc39cb90cf7a3cfb3178e1b1779421990658
            BindingContext = ViewModel;
        }
    }
}