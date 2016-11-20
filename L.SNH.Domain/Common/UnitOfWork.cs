using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Common
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork()
        {
            FluentConfiguration flcfg = Fluently.Configure();
            if (true) // SQLITE
            {
                flcfg
                    .Database(SQLiteConfig());
            }
            flcfg.Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
            flcfg.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true));
            _sessionFactory = flcfg.BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }

        //public ISessionFactory CreateSessionFactory()
        //{
        //    FluentConfiguration flcfg = Fluently.Configure();
        //    if (true) // SQLITE
        //    {
        //        flcfg
        //            .Database(SQLiteConfig());
        //    }
        //    flcfg.Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
        //    flcfg.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true));
        //    return flcfg.BuildSessionFactory();
        //}

        static IPersistenceConfigurer SQLiteConfig()
        {
            return SQLiteConfiguration.Standard.ConnectionString(
                c => c.FromConnectionStringWithKey("MyConnectionString"));
        }
    }
}
