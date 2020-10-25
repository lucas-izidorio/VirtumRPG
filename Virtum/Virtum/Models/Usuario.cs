using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Usuario
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}