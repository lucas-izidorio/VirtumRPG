using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Usuario : DatabaseModel<Usuario>
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("amigos")]
        public List<Jogador> Amigos { get; set; }

        [JsonProperty("reinos")]
        public List<Reino> Reinos { get; set; }

        #region Informações do Banco Local
        public bool Logado { get; set; }
        #endregion
    }
}