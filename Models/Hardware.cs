using System;

namespace Admin.Models
{
    public class Hardware
    {
        public virtual int Id { get; set; }
        public virtual string Tipo { get; set; } = string.Empty;
        public virtual string NumeroSerie { get; set; } = string.Empty;
        public virtual DateTime Aquisicao { get; set; }
        public virtual string Nome { get; set; } = string.Empty;
        public virtual string Status { get; set; } = string.Empty;
        public virtual string EnderecoHardware { get; set; } = string.Empty;
    }
}
