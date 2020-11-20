using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Virtum.Models;
using Virtum.Services;
using Virtum.Utils;
using Virtum.Views;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CadastroViewModel
    {
        public ICommand VisualizarLoginCommand { get; private set; }
        public ICommand CadastrarCommand { get; private set; }

        private INavigation Navigation { get; set; }

        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public CadastroViewModel(INavigation nav)
        {
            VisualizarLoginCommand = new Command(VisualizarLogin);
            CadastrarCommand = new Command(CadastrarUsuario);
            Navigation = nav;
        }

        async void VisualizarLogin()
        {
            await Navigation.PopToRootAsync();
        }

        async void CadastrarUsuario()
        {
            if (ValidarCampos())
            {
                var usuario = new Usuario()
                {
                    Nome = this.Nickname,
                    Email = this.Email,
                    Senha = this.Senha
                };

                try
                {
                    var resultado = await VirtumApi.Instance.CadastrarUsuario(usuario);

                    Console.WriteLine("Resultado recebido: " + resultado.Status + " - " + resultado.Mensagem);

                    Usuario usuarioBanco = Usuario.Read().Where(x => x.Id == resultado.Usuario.Id).FirstOrDefault();
                    if (usuarioBanco == null)
                    {
                        usuario = resultado.Usuario;
                        usuario.Logado = true;
                        Usuario.Insert(usuario);
                    }
                    else
                    {
                        usuarioBanco.Logado = true;
                        Usuario.Save(usuarioBanco);
                    }

                    await Navigation.PushAsync(new MainPage());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Algum campo não foi preenchido corretamente");
            }
        }

        bool ValidarCampos()
        {
            return Nickname.Length > 0 && Utilitarios.VerificarEmail(Email) && Senha.Length > 0;
        }
    }
}
