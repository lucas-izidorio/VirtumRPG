using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Virtum.Models;
using Virtum.Views;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NovaMesaViewModel
    {
        public ICommand OnCreateTableCommand { get; private set; }

        private INavigation Navigation { get; set; }

        public string BuscaMesa { get; set; }
        public Usuario User { get; set; }
        public ObservableCollection<Reino> RealmList { get; set; }
        public ICommand CommandOpenTable { get; set; }

        public NovaMesaViewModel(INavigation nav)
        {
            #region Definição de Comandos
            OnCreateTableCommand = new Command(CriarMesa);
            CommandOpenTable = new Command(OpenTable);
            #endregion

            #region Inicialização de Variáveis da Tela
            User = Usuario.Read().FirstOrDefault(x => x.Logado == true);
            if (User != null)
            {
                if (User.Reinos != null)
                {
                    RealmList = new ObservableCollection<Reino>(this.User.Reinos);
                }
            }
            else
            {
                RealmList = new ObservableCollection<Reino>();
            }
            #endregion

            #region Iniciação do Contexto de Navegação
            Navigation = nav;
            #endregion
        }

        async void CriarMesa()
        {
            await Navigation.PushAsync(new CriarMesaPage());
        }

        async void OpenTable()
        {
            await Navigation.PushAsync(new MesaPage());
        }
    }
}
