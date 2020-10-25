using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel;
        protected override void OnAppearing()
        {
            ArrayList amigos = new ArrayList
            {
                "Lucas",
                "Lucas",
                "Lucas",
                "Lucas",
                "rodrigo"
            };
            Amigos.ItemsSource = amigos;
        }
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel(Navigation);
            BindingContext = ViewModel;
        }
    }
}