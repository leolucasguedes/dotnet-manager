using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using global::NHibernate;
using NHibernate.Tool.hbm2ddl;
using Admin.Models;

namespace Admin.Context
{
    public static class HardwareContext
    {
        private static global::NHibernate.ISessionFactory _sessionFactory = null!;

        public static global::NHibernate.ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        static HardwareContext()
        {
            InitializeSessionFactory();
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=hardware.db;Version=3;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HardwareMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }
    }
}
