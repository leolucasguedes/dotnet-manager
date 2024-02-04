using System;

namespace Admin.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime Aquisicao { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public string EnderecoHardware { get; set; }
    }
}
