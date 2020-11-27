using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtum.Models;
using Virtum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusPlayer : ContentPage
    {
        public FichaViewModel ViewModel;
        public StatusPlayer(Ficha ficha, Reino reino)
        {
            InitializeComponent();
            ViewModel = new FichaViewModel(Navigation, ficha, reino);
            BindingContext = ViewModel;
        }
    }
}