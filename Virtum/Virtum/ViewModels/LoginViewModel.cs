using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Virtum.Views;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        public ICommand VisualizarCadastroCommand { get; private set; }
        public ICommand EntrarCommand { get; private set; }
        private INavigation Navigation { get; set; }

        public LoginViewModel(INavigation nav)
        {
            VisualizarCadastroCommand = new Command(VisualizarCadastro);
            EntrarCommand = new Command(Entrar);
            Navigation = nav;
        }

        async void VisualizarCadastro()
        {
            await Navigation.PushAsync(new CadastroPage());
        }

        async void Entrar()
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
