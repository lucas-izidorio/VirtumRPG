using System;
using Virtum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel;

        [System.Obsolete]
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel(Navigation);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            Console.WriteLine("Carregando usuario");
            this.ViewModel.CarregarUsuario();
        }
    }
}