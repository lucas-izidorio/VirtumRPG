using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Models
{
    public class Jogador:DatabaseModel<Jogador>
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
