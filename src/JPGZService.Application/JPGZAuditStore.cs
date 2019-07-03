using Abp.Auditing;
using Abp.Dependency;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JPGZService
{
    public class JPGZAuditStore : IAuditingStore, ITransientDependency
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;
        public JPGZAuditStore(IRepository<AuditLog, long> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }
        public Task SaveAsync(AuditInfo auditInfo)
        {
            return _auditLogRepository.InsertAsync(AuditLog.CreateFromAuditInfo(auditInfo));
        }
    }
}
