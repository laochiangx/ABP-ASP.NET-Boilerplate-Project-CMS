using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.Permissionse
{
    public class PermissionDto //: EntityDto<int>
    {
         public string  id { get; set; }
        public int  TenantId { get; set; }
        public string Name { get; set; }

        public bool IsGranted { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatorUserId { get; set; }
        public int  RoleId { get; set; }
        public string UserId { get; set; }
        public string Discriminator { get; set; }


    }
}
