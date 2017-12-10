using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace ABPCMS.Articles
{
    [Serializable]
    public class Article:FullAuditedEntity
    {
        public string Title { get; set; }
    }
}
