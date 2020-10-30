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
        private const string URL = "70.37.96.134/";
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

        public async Task<Responses.AdicionarAmigoResponse> AdicionarAmigo(Jogador jogador)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.AdicionarAmigo(jogador);
        }
    }
}
