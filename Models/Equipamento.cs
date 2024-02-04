using System;

namespace Admin.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string NumeroSerie { get; set; } = string.Empty;
        public DateTime Aquisicao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string EnderecoHardware { get; set; } = string.Empty;
    }
}
