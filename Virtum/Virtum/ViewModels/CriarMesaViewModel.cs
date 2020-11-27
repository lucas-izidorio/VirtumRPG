using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Virtum.Services;
using Virtum.Models;
using Xamarin.Forms;
using System.Linq;
using Virtum.Views;

namespace Virtum.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CriarMesaViewModel
    {
        public ICommand OnCreateTableCommand { get; private set; }

        private INavigation Navigation { get; set; }

        public Usuario User { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public CriarMesaViewModel(INavigation nav)
        {
            Tipo = "D&D";

            OnCreateTableCommand = new Command(CriarMesa);

            User = Usuario.Read().FirstOrDefault(x => x.Logado == true);

            Navigation = nav;
        }

        Responses.CriarReinoResponse FakeCriarReino()
        {

            return new Responses.CriarReinoResponse()
            {
                Mensagem = "Sucesso",
                Reino = new Reino()
                {
                    Id = "#10",
                    IdMestre = User.Id,
                    NomeMestre = User.Nome,
                    Nome = this.Nome,
                    Categoria = this.Tipo,
                    Descricao = this.Descricao
                },
                Status = true
            };
        }

        async void CriarMesa()
        {
            try
            {
                var novoReino = new Reino()
                {
                    IdMestre = User.Id,
                    NomeMestre = User.Nome,
                    Nome = this.Nome,
                    Categoria = this.Tipo,
                    Descricao = this.Descricao
                };
                var resultado = await VirtumApi.Instance.CriarReino(novoReino);

                Console.WriteLine("Resultado request: " + resultado.Mensagem);

                if (resultado.Status == true)
                {
                    var usuario = Usuario.Read().Where(x => x.Logado = true).FirstOrDefault();
                    Console.WriteLine("Resultado usuario: " + usuario.Nome);
                    var resultadoReino = await VirtumApi.Instance.BuscarReinos(new Filtro()
                    {
                        Nome = novoReino.Nome
                    });

                    Console.WriteLine("Resultado resultadoReino: " + resultadoReino.Reinos);
                    if (resultadoReino.Reinos.Count > 0)
                    {
                        novoReino.Id = resultadoReino.Reinos[0].Id;
                    }
                    Console.WriteLine("Reino final: " + novoReino.Id);

                    try
                    {
                        usuario.Reinos.Add(novoReino);
                    }
                    catch (Exception ex)
                    {
                        usuario.Reinos = new List<Reino>();
                        usuario.Reinos.Add(novoReino);
                    }
                    Usuario.Save(usuario);
                    Reino.Save(novoReino);
                    Console.WriteLine("Usuario salvado: " + usuario.Reinos.Count);
                    await Navigation.PushAsync(new MesaPage(novoReino));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
