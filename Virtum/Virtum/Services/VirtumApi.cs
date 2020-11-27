using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtum.Models;
using Virtum.Utils;

namespace Virtum.Services
{
    class VirtumApi : Singleton<VirtumApi>
    {
        private const string URL = "http://7f06849ca0ba.ngrok.io";
        public async Task<Responses.CadastrarUsuarioResponse> CadastrarUsuario(Usuario usuario)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.CadastrarUsuario(usuario);
        }
        public async Task<Responses.LoginResponse> Login(Usuario usuario)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.Login(usuario);
        }
        public async Task<Responses.AlterarNomeResponse> AlterarNome(Usuario usuario)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.AlterarNome(usuario);
        }

        public async Task<Responses.AdicionarAmigoResponse> AdicionarAmigo(Jogador jogador, Usuario usuario)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.AdicionarAmigo(jogador, usuario);
        }

        public async Task<Responses.CriarReinoResponse> CriarReino(Reino reino)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.CriarReino(reino);
        }

        public async Task<Responses.BuscarReinosResponse> BuscarReinos(Filtro filtro)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.BuscarReino(filtro);
        }

        public async Task<Responses.EditarReinoResponse> EditarReino(Reino reino)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.EditarReino(reino);
        }

        public async Task<Responses.AdicionarPersonagemResponse> AdicionarPersonagem(Reino reino, Ficha ficha)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.AdicionarPersonagem(reino, ficha);
        }

        public async Task<Responses.BuscarPersonagensResponse> BuscarPersonagens(Reino reino, Ficha ficha)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.BuscarPersonagens(reino, ficha);
        }
    }
}
