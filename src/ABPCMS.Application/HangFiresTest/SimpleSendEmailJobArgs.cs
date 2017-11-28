using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFiresTest
{
    [Serializable]
    public class SimpleSendEmailJobArgs
    {
        public long SenderUserId { get; set; }

        public long TargetUserId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
