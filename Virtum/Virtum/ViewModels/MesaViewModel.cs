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
    public class MesaViewModel
    {

        public ICommand OnAddFriendTableCommand { get; private set; }

        private INavigation Navigation { get; set; }
        public Usuario User { get; set; }
        public ObservableCollection<Jogador> PlayerList { get; set; }
        public ICommand CommandOpenStatusPlayer { get; set; }

        public MesaViewModel(INavigation nav, Reino reino)
        {
            #region Definição de Comandos
            OnAddFriendTableCommand = new Command(AddFriendTable);
            CommandOpenStatusPlayer = new Command(OpenStatusPlayer);
            #endregion

            #region Inicialização de Variáveis da Tela
<<<<<<< HEAD
            User = Usuario.Read().FirstOrDefault(x => x.Logado == true);
            if (User != null)
            {
                if (User.Amigos != null)
                {
                    PlayerList = new ObservableCollection<Jogador>(this.User.Amigos);
                }
            }
            else
            {
                PlayerList = new ObservableCollection<Jogador>();
            }
=======
            TheReino = reino;
>>>>>>> e237bc39cb90cf7a3cfb3178e1b1779421990658
            #endregion

            #region Iniciação do Contexto de Navegação
            Navigation = nav;
            #endregion
        }

        async void AddFriendTable()
        {
            await PopupNavigation.PushAsync(new PopUp_AddFriend());
        }
        async void OpenStatusPlayer()
        {
            await Navigation.PushAsync(new StatusPlayer());
        }


    }
}
