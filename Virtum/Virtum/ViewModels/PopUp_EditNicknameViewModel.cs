using PropertyChanged;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
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
    public class PopUp_EditNicknameViewModel
    {
        public ICommand OnEditNameCommand { get; private set; }
        public PopUp_EditNickname Page { get; set; }

        public string Nickname { get; set; }
        public PopUp_EditNicknameViewModel(PopUp_EditNickname page)
        {
            OnEditNameCommand = new Command(EditName);
            Page = page;
        }

        async void EditName()
        {
            try
            {
                var usuario = Usuario.Read().Where(x => x.Logado = true).FirstOrDefault();
                usuario.Nome = Nickname;
                var resultado = await VirtumApi.Instance.AlterarNome(usuario);

                Console.WriteLine("Nick alterado para: " + Nickname + " - Resultado recebido: " + resultado.Status + " - " + resultado.Mensagem);

                Usuario.Save(usuario);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                await PopupNavigation.PopAsync(true);
                Page.OnFinish();
            }
        }
    }
}
