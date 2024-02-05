using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using global::NHibernate;
using NHibernate.Tool.hbm2ddl;
using Admin.Models;
using Admin.Context;

namespace Admin.Context
{
    public static class NHibernateConfig
    {
        private static global::NHibernate.ISessionFactory _sessionFactory;

        public static global::NHibernate.ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        static NHibernateConfig()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=hardware.db;Version=3;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HardwareMap>())
                .ExposeConfiguration(cfg => new NHibernate.Tool.hbm2ddl.SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }
    }
}
