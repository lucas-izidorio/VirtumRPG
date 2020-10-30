using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtum.Models;

namespace Virtum.Services
{
    public interface IVirtumApi
    {
        [Post("/cadastrar")]
        Task<Responses.CadastrarUsuarioResponse> CadastrarUsuario([Body] Usuario parametros);

        [Post("/login")]
        Task<Responses.LoginResponse> Login([Body] Usuario parametros);

        [Post("/alterarnome")]
        Task<Responses.AlterarNomeResponse> AlterarNome([Body] Usuario parametros);

        [Post("/alterarnome")]
        Task<Responses.AdicionarAmigoResponse> AdicionarAmigo([Body] Jogador parametros);
    }
}
