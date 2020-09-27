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
        private const string URL = "http://demo4530435.mockable.io/";
        public async Task<Responses.CadastrarUsuarioResponse> CadastrarUsuario(Usuario usuario)
        {
            var api = RestService.For<IVirtumApi>(URL);
            return await api.CadastrarUsuario(usuario);
        }
    }
}
