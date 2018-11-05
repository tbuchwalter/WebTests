using System;

namespace MyProject.Web.Models
{
    public class BaseViewModelEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public long CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
