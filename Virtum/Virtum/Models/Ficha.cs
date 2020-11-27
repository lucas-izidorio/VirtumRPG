using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtum.Models
{
    public class Ficha
    {
        [JsonProperty("nome_jogador")]
        public string NomeJogador { get; set; }

        [JsonProperty("id_jogador")]
        public string IdJogador { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("historia")]
        public string Historia { get; set; }

        [JsonProperty("classe")]
        public string Classe { get; set; }

        [JsonProperty("raca")]
        public string Raca { get; set; }

        [JsonProperty("nivel")]
        public string Nivel { get; set; }

        [JsonProperty("habilidade")]
        public string Habilidade { get; set; }

        [JsonProperty("equipamento")]
        public string Equipamento { get; set; }

        [JsonProperty("vida_total")]
        public string VidaTotal { get; set; }

        [JsonProperty("vida_atual")]
        public string VidaAtual { get; set; }

        [JsonProperty("deslocamento")]
        public string Deslocamento { get; set; }

    }
}
