using Rg.Plugins.Popup.Services;
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
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel(Navigation);
            BindingContext = ViewModel;
        }
        private async void Button_EditNickname(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new PopUp_EditNickname());
        }

        private async void Button_AddFriend(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new PopUp_AddFriend());
        }
    }
}