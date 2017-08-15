using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCms.Meuns
{
    public class Meun : Entity<int>, IMayHaveTenant
    {
        public int? ParentId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LinkUrl { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsMenu { get; set; }
        public int Code { get; set; }
        public bool Enabled { get; set; }

        public DateTime UpdateDate { get; set; }
        public int? TenantId { get; set; }

    
    }
}
