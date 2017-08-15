using JCms.Meuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JCMS.Web.Areas.Common.Models
{
    public class MeunViewModel
    {
        public List<MeunDto> _LPBasicSet = new List<MeunDto>();
        public List<MeunDto> LPBasicSet
        {
            get { return _LPBasicSet; }
            set { _LPBasicSet = value; }
        }
    }
}