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
    public class LoginViewModel
    {
        public ICommand VisualizarCadastroCommand { get; private set; }
        public ICommand EntrarCommand { get; private set; }
        private INavigation Navigation { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginViewModel(INavigation nav)
        {
            VisualizarCadastroCommand = new Command(VisualizarCadastro);
            EntrarCommand = new Command(Entrar);
            Navigation = nav;

            ConferirUsuarioLogado();
        }

        async void ConferirUsuarioLogado()
        {
            Usuario usuarioBanco = Usuario.Read().Where(x => x.Logado == true).FirstOrDefault();
            if (usuarioBanco != null)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        async void VisualizarCadastro()
        {
            await Navigation.PushAsync(new CadastroPage());
        }

        private Responses.LoginResponse FakeLogin()
        {
            return new Responses.LoginResponse()
            {
                Mensagem = "Fake login",
                Status = true,
                Usuario = new Usuario()
                {
                    Id = "#0",
                    Email = "user@mail.com",
                    Nome = "JohnDoe",
                    Logado = true,
                    Senha = "123",
                    Amigos = new List<Jogador>() {
                        new Jogador()
                        {
                            Id = "#1",
                            Nome = "JohnDoe"
                        }
                    },
                    Reinos = new List<Reino>() {
                        new Reino()
                        {
                            Id = "#0",
                            Nome = "Reino de Valdrin",
                            Categoria = "D&D",
                            IdMestre = "#1"
                        },
                        new Reino()
                        {
                            Id = "#1",
                            Nome = "Reino de Teras Sombrias",
                            Categoria = "D&D",
                            IdMestre = "#0"
                        }
                    }
                }
            };
        }

        async void Entrar()
        {
            if (ValidarCampos())
            {
                var usuario = new Usuario()
                {
                    Email = this.Email,
                    Senha = this.Senha
                };

                try
                {
                    var resultado = FakeLogin();//await VirtumApi.Instance.Login(usuario);

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
            return Utilitarios.VerificarEmail(Email) && Senha.Length > 0;
        }
    }
}
