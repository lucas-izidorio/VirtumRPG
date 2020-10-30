using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class PopUp_EditNickname : PopupPage
    {
        public PopUp_EditNicknameViewModel ViewModel;
        public delegate void HandlePopDelegate(string parameter);
        public event HandlePopDelegate DidFinishPoping;
        public PopUp_EditNickname()
        {
            InitializeComponent();
            ViewModel = new PopUp_EditNicknameViewModel(this);
            BindingContext = ViewModel;
        }

        public void OnFinish()
        {
            DidFinishPoping("Username");
        }
    }
}