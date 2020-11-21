using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Virtum.Models;

namespace Virtum.Services
{
    public class Responses
    {
        public class CadastrarUsuarioResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }

            [JsonProperty("user")]
            public Usuario Usuario { get; set; }
        }
        public class LoginResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }

            [JsonProperty("user")]
            public Usuario Usuario { get; set; }
        }

        public class AlterarNomeResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }

            [JsonProperty("user")]
            public Usuario Usuario { get; set; }
        }

        public class AdicionarAmigoResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }
        }

        public class CriarReinoResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }
        }

        public class BuscarReinosResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("reinos")]
            public List<Reino> Reinos { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }
        }

        public class EditarReinoResponse
        {
            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("mensagem")]
            public string Mensagem { get; set; }
        }
    }
}
