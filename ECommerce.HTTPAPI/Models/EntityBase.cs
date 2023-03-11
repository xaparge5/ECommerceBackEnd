using System.ComponentModel.DataAnnotations;

namespace ECommerce.HTTPAPI.Models
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
