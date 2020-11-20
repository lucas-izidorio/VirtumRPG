using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CriarMesaViewModel
    {
        public ICommand OnCreateTableCommand { get; private set; }

        private INavigation Navigation { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public CriarMesaViewModel(INavigation nav)
        {
            Tipo = "D&D";

            OnCreateTableCommand = new Command(CriarMesa);

            Navigation = nav;
        }

        async void CriarMesa()
        {

        }
    }
}
