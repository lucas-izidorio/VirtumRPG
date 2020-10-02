using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Services
{
    public class Responses
    {
        public class CadastrarUsuarioResponse
        {
            [JsonProperty("resultado")]
            public bool Resultado { get; set; }
        }
        public class LoginResponse
        {
            [JsonProperty("resultado")]
            public bool Resultado { get; set; }
        }
    }
}
