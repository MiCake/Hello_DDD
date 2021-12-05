using MiCake.Audit;
using MiCake.Audit.SoftDeletion;
using MiCake.DDD.Domain;

namespace NoInvolution.MassageShop.Domain.Common
{
    public class AuditAggregateRoot<TKey> : AggregateRoot<TKey>, IHasAudit, IHasCreator<TKey>, IHasModifyUser<TKey>
    {
        public DateTime CreationTime { get; set; }

        public DateTime? ModificationTime { get; set; }

        public TKey CreatorID { get; set; }

        public TKey ModifyUserID { get; set; }
    }

    public class AuditAggregateRoot : AggregateRoot<int>, IHasAudit, IMayHasCreator<int>, IMayHasModifyUser<int>
    {
        public DateTime CreationTime { get; set; }

        public DateTime? ModificationTime { get; set; }

        public int? CreatorID { get; set; }

        public int? ModifyUserID { get; set; }
    }

    public class AuditSoftDeleteAggregateRoot<TKey> : AuditAggregateRoot<TKey>, ISoftDeletion, IHasDeletionTime, IHasDeleteUser<TKey>
    {
        public DateTime? DeletionTime { get; set; }
        public TKey DeleteUserID { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class AuditSoftDeleteAggregateRoot : AuditAggregateRoot, ISoftDeletion, IHasDeletionTime, IMayHasDeleteUser<int>
    {
        public DateTime? DeletionTime { get; set; }
        public int? DeleteUserID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
