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
        private INavigation Navigation { get; set; }

        public Reino TheReino { get; set; }

        public MesaViewModel(INavigation nav, Reino reino)
        {
            #region Definição de Comandos

            #endregion

            #region Inicialização de Variáveis da Tela
            TheReino = reino;
            #endregion

            #region Iniciação do Contexto de Navegação
            Navigation = nav;
            #endregion
        }
    }
}
