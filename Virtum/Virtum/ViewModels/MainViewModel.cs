using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Virtum.Models;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ICommand OnEditNameCommand { get; private set; }
        public ICommand OnChatTappedCommand { get; private set; }
        private INavigation Navigation { get; set; }

        public Usuario User { get; set; }
        public ObservableCollection<Usuario> FriendsList { get; set; }

        public MainViewModel(INavigation nav)
        {
            OnEditNameCommand = new Command(EditName);
            OnChatTappedCommand = new Command(ChatWith);
            this.User = new Usuario()
            {
                Nome = "Nickname"
            };
            Navigation = nav;
        }

        void EditName()
        {
            this.User.Nome = "Lucas";
        }

        void ChatWith()
        {

        }
    }
}
