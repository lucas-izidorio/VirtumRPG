using Virtum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MesaPage : ContentPage
    {
        public MesaViewModel ViewModel;

        public MesaPage()
        {
            InitializeComponent();
            ViewModel = new MesaViewModel(Navigation);
            BindingContext = ViewModel;
        }
    }
}