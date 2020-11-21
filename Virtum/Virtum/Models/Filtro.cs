using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Models
{
    public class Filtro
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
