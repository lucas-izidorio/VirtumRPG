using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
        public ICommand OnAddFriendCommand { get; private set; }
        private INavigation Navigation { get; set; }

        public Usuario User { get; set; }
        public ObservableCollection<Jogador> FriendsList { get; set; }

        public MainViewModel(INavigation nav)
        {
            #region Definição de Comandos
            OnEditNameCommand = new Command(EditName);
            OnAddFriendCommand = new Command(AddFriend);
            #endregion

            #region Inicialização de Variáveis da Tela
            User = Usuario.Read().FirstOrDefault(x => x.Logado == true);
            if (User != null && User.Amigos != null)
            {
                FriendsList = new ObservableCollection<Jogador>(this.User.Amigos);
            }
            else
            {
                FriendsList = new ObservableCollection<Jogador>();
            }
            #endregion

            #region Iniciação do Contexto de Navegação
            Navigation = nav;
            #endregion
        }

        void EditName()
        {
            // TODO: Abrir modal para editar o nome, e adicionar um listener do botão para chamar uma requisição e alterar o nome via servidor
            /*
             Exemplo de requisição: (Cadastro de Usuário) -- obs.: é preciso que o back-end implemente a função de trocar de nome antes de consumir

                try
                {
                    var resultado = await VirtumApi.Instance.CadastrarUsuario(usuario);

                    Console.WriteLine("Resultado recebido: " + resultado.Resultado);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

             */
        }

        void AddFriend()
        {
            // TODO: Abrir modal para inserir o ID de algum usuário e adicioná-lo (deverá consumir uma função do back-end de requisição no servidor para buscar dados a partir do ID)
        }
    }
}
