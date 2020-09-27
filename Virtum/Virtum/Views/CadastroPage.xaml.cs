using System;
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
    public partial class CadastroPage : ContentPage
    {
        public CadastroViewModel ViewModel;
        public CadastroPage()
        {
            InitializeComponent();
            ViewModel = new CadastroViewModel(Navigation);
            BindingContext = ViewModel;
        }
    }
}