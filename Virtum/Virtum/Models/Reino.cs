using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Models
{
    public class Reino : DatabaseModel<Reino>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("id_mestre")]
        public string IdMestre { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }
    }
}
