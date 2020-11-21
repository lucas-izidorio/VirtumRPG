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
    public partial class StatusPlayer : ContentPage
    {
        public StatusPlayerViewModel ViewModel;
        public StatusPlayer()
        {
            InitializeComponent();
            ViewModel = new StatusPlayerViewModel(Navigation);
            BindingContext = ViewModel;
        }
    }
}