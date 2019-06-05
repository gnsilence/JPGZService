//using Abp.Dependency;
//using Abp.Domain.Uow;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ABP.FreeSqlSqlserver.ABPFreeSql.Uow
//{
//    public class UnitOfWorkFreesqlProvider : IFreeSqlProvider, ITransientDependency
//    {
//        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWork;
//        public UnitOfWorkFreesqlProvider(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
//        {
//            _currentUnitOfWork = currentUnitOfWorkProvider;
//        }
//        public IFreeSql freeSql => ((FreeSqlUnitOfWork)_currentUnitOfWork.Current).freeSql;
//    }
//}
