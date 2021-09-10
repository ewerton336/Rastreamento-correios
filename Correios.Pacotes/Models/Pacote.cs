using System.Collections.Generic;

namespace Correios.Pacotes.Models
{
    public class Pacote
    {
        public string Codigo { get; set; }
        public List<Status> Historico { get; internal set; }
        public bool Entregue { get; internal set; }
        public bool IsValid { get; internal set; }
        public string Observacao { get; internal set; }
    }
}
