using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.Permissionse
{
    public class Permissions : Entity<int>//,IMayHaveTenant
    {
       // public int id { get; set; }
        public string Name { get; set; }

        public bool IsGranted { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatorUserId { get; set; }
        public int  RoleId { get; set; }
        public string UserId { get; set; }
        public string Discriminator { get; set; }

        public int  TenantId { get; set; }
    }
}
