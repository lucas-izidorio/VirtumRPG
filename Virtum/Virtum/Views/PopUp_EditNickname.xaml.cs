using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Virtum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp_EditNickname : PopupPage
    {
        public PopUp_EditNickname()
        {
            InitializeComponent();
        }

        private async void Button_EditNickname(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
    }
}