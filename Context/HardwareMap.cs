using FluentNHibernate.Mapping;
using Admin.Models;

namespace Admin.Context
{
    public class HardwareMap : ClassMap<Hardware>
    {
        public HardwareMap()
        {
            Table("Equipamento");

            Id(x => x.Id);
            Map(x => x.Tipo);
            Map(x => x.NumeroSerie);
            Map(x => x.Aquisicao);
            Map(x => x.Nome);
            Map(x => x.Status);
            Map(x => x.EnderecoHardware);
        }
    }
}
