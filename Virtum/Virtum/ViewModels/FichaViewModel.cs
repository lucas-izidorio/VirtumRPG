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
using Virtum.Services;
using Virtum.Views;
using Xamarin.Forms;

namespace Virtum.ViewModels
{
    public class FichaViewModel
    {
        public ICommand BotaoCommand { get; set; }

        public Ficha Ficha { get; set; }
        public Reino Reino { get; set; }
        public string ClasseNome { get; set; }
        public string Jogador { get; set; }
        public string Botao { get; set; }

        private INavigation Navigation;
        private bool NovaFicha;

        public FichaViewModel(INavigation nav, Ficha ficha, Reino reino)
        {
            NovaFicha = ficha.IdJogador.Length == 0;

            Ficha = ficha;
            Reino = reino;
            ClasseNome = ficha.Classe + " " + ficha.Nome;
            Jogador = ficha.NomeJogador + ficha.IdJogador;

            Botao = NovaFicha ? "Criar Ficha" : "Salvar Ficha";

            BotaoCommand = new Command(AcaoBotao);

            Navigation = nav;
        }

        async void AcaoBotao()
        {
            Console.WriteLine("Ficha: " + Ficha.Habilidade);
            try
            {
                Ficha.Id = Reino.Id;
                if (NovaFicha)
                {
                    var user = Usuario.Read().FirstOrDefault(x => x.Logado == true);
                    Ficha.IdJogador = user.Id;
                    var resultado = await VirtumApi.Instance.AdicionarPersonagem(Ficha);

                    Console.WriteLine("Resultado: " + resultado);
                    if (resultado.Status == true)
                    {
                        try
                        {
                            user.Reinos.Add(Reino);
                        }
                        catch (Exception ex)
                        {
                            user.Reinos = new List<Reino>();
                            user.Reinos.Add(Reino);
                        }
                        Usuario.Save(user);
                        Reino.Save(Reino);
                        //Reino.Fichas.Add(Ficha);
                    }
                }
                else
                {

                }

                await Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
        }
    }
}
