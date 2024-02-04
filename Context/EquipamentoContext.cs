using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Admin.Context
{
    public static class EquipamentoContext
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        static EquipamentoContext()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=equipamento.db;Version=3;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EquipamentoContext>())
                .BuildSessionFactory();
        }
    }
}
