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
using Virtum.Services;
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
        public Reino TheReino { get; set; }
        public ObservableCollection<Ficha> PlayerList { get; set; }
        public ICommand CommandOpenStatusPlayer { get; set; }
        public ICommand CriarFichaCommand { get; set; }

        public MesaViewModel(INavigation nav, Reino reino)
        {
            #region Definição de Comandos
            OnAddFriendTableCommand = new Command(AddFriendTable);
            CommandOpenStatusPlayer = new Command<string>(OpenStatusPlayer);
            CriarFichaCommand = new Command(OpenStatusPlayer);
            #endregion

            #region Inicialização de Variáveis da Tela
            TheReino = reino;
            BuscarFichas();
            //PlayerList = new ObservableCollection<Ficha>(TheReino.Fichas);
            #endregion

            #region Iniciação do Contexto de Navegação
            Navigation = nav;
            #endregion
        }

        async void AddFriendTable()
        {
            await PopupNavigation.PushAsync(new PopUp_AddFriend());
        }
        async void OpenStatusPlayer(string id)
        {
            var ficha = PlayerList.FirstOrDefault(x => x.IdJogador == id);
            var page = new StatusPlayer(ficha, TheReino);
            page.Disappearing += (sender, e) =>
            {
                BuscarFichas();
            };
            await Navigation.PushAsync(page);
        }

        async void OpenStatusPlayer()
        {
            var ficha = new Ficha()
            {
                IdJogador = "",
                Nome = "Novo Personagem"
            };
            var page = new StatusPlayer(ficha, TheReino);
            page.Disappearing += (sender, e) =>
            {
                BuscarFichas();
            };
            await Navigation.PushAsync(page);
        }

        async void BuscarFichas()
        {
            try
            {
                Console.WriteLine("Reino: " + TheReino.Id);
                var resultado = await VirtumApi.Instance.BuscarPersonagens(TheReino);

                Console.WriteLine("Resultado: " + resultado.Fichas + " | " + resultado.Mensagem);

                if (resultado.Status == true)
                {
                    PlayerList = new ObservableCollection<Ficha>(resultado.Fichas);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
        }
    }
}
