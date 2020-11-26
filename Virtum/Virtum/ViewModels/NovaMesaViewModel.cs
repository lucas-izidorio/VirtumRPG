using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class NovaMesaViewModel
    {
        public ICommand OnCreateTableCommand { get; private set; }
        public ICommand OnBuscarMesaCommand { get; private set; }

        private INavigation Navigation { get; set; }

        public string BuscaMesa { get; set; }
        public Usuario User { get; set; }
        public ObservableCollection<Reino> RealmList { get; set; }

        public NovaMesaViewModel(INavigation nav)
        {
            #region Definição de Comandos
            OnCreateTableCommand = new Command(CriarMesa);
            OnBuscarMesaCommand = new Command(PesquisarMesas);
            #endregion

            #region Inicialização de Variáveis da Tela
            BuscaMesa = "";
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

        async void PesquisarMesas()
        {
            var resultado = FakeBuscarReinos();/*await VirtumApi.Instance.BuscarReinos(new Filtro()
            {
                Nome = this.BuscaMesa
            });*/

            RealmList.Clear();

            foreach (Reino reino in resultado.Reinos)
            {
                RealmList.Add(reino);
            }
        }

        Responses.BuscarReinosResponse FakeBuscarReinos()
        {

            return new Responses.BuscarReinosResponse()
            {
                Mensagem = "Sucesso",
                Status = true,
                Reinos = new List<Reino>() {
                    new Reino()
                    {
                        Id = "#2",
                        Nome = "Reino de Contagem",
                        Categoria = "D&D",
                        IdMestre = "#1"
                    },
                    new Reino()
                    {
                        Id = "#3",
                        Nome = "Reino de Águas de Sentina",
                        Categoria = "D&D",
                        IdMestre = "#0"
                    }
                }
            };
        }

        async void CriarMesa()
        {
            await Navigation.PushAsync(new CriarMesaPage());
        }
    }
}
