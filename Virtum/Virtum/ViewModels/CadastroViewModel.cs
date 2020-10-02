using PropertyChanged;
using System;
using System.Collections.Generic;
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
            VisualizarLoginCommand = new Command(VisualizarCadastro);
            CadastrarCommand = new Command(CadastrarUsuario);
            Navigation = nav;
        }

        async void VisualizarCadastro()
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

                    Console.WriteLine("Resultado recebido: " + resultado.Resultado);
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
