using PropertyChanged;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Virtum.Models;
using Virtum.Views;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ICommand OnEditNameCommand { get; private set; }
        public ICommand OnAddFriendCommand { get; private set; }
        private INavigation Navigation { get; set; }

        public Usuario User { get; set; }
        public ObservableCollection<Jogador> FriendsList { get; set; }
        public ObservableCollection<Reino> RealmList { get; set; }

        public MainViewModel(INavigation nav)
        {
            #region Definição de Comandos
            OnEditNameCommand = new Command(EditName);
            OnAddFriendCommand = new Command(AddFriend);
            #endregion

            #region Inicialização de Variáveis da Tela
            User = Usuario.Read().FirstOrDefault(x => x.Logado == true);
            if (User != null)
            {
                if (User.Amigos != null)
                {
                    FriendsList = new ObservableCollection<Jogador>(this.User.Amigos);
                }
                if (User.Reinos != null)
                {
                    RealmList = new ObservableCollection<Reino>(this.User.Reinos);
                }
            }
            else
            {
                FriendsList = new ObservableCollection<Jogador>();
                RealmList = new ObservableCollection<Reino>();
            }
            #endregion

            RealmList.Add(new Reino()
            {
                IdMestre = "#3",
                Nome = "Reino de Killucas"
            });

            #region Iniciação do Contexto de Navegação
            Navigation = nav;
            #endregion
        }

        async void EditName()
        {
            var page = new PopUp_EditNickname();
            page.DidFinishPoping += (parameter) =>
            {
                User = Usuario.Read().FirstOrDefault(x => x.Logado == true);
            };
            await PopupNavigation.PushAsync(page);
        }

        async void AddFriend()
        {
            await PopupNavigation.PushAsync(new PopUp_AddFriend());
        }
    }
}
