using System.ComponentModel.DataAnnotations;
namespace BaseLibrary.Entities
{
    public abstract class AuditBaseEntity : BaseEntity
    {
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }


}
