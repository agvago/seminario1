﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Seminario.Model;
using Seminario.NHibernate.Mapping;
using NHibernate.Linq;
using FluentNHibernate.Utils;
namespace Seminario.NHibernate
{
    public static class SessionFactoryBuilder
    {
        public static ISession OpenSession()
        {
            string connectionString = "Data Source=ELAD\\SQLEXPRESS;Initial Catalog=Seminario;Integrated Security=SSPI;";
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(connectionString).ShowSql()
                   )
                .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<ChequeMap>()
                              .AddFromAssemblyOf<ProvinciaMap>()
                              .AddFromAssemblyOf<DatosTTMap>()
                              .AddFromAssemblyOf<ProductoMap>()
                              .AddFromAssemblyOf<SimulacionMap>()
                              .AddFromAssemblyOf<Empleado>()
                              )
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                 .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
