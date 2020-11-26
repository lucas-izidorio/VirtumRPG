﻿using PropertyChanged;
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
            var resultado = FakeCriarReino();/*await VirtumApi.Instance.CriarReino(new Reino()
            {
                Id = "",
                IdMestre = User.Id,
                NomeMestre = User.Nome,
                Nome = this.Nome,
                Categoria = this.Tipo,
                Descricao = this.Descricao
            });*/

            if (resultado.Status == true)
            {
                await Navigation.PushAsync(new MesaPage(resultado.Reino));
            }
        }
    }
}
