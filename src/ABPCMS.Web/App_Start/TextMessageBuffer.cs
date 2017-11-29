using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ABPCMS.Web.App_Start
{
    public static class TextMessageBuffer
    {
        private static readonly StringBuilder strBuff = new StringBuilder();

        public static void WriteLine(string value)
        {
            lock (strBuff)
            {
                strBuff.AppendLine(String.Format("{0} {1}", DateTime.Now, value));
            }
        }

        public new static string ToString()
        {
            lock (strBuff)
            {
                return strBuff.ToString();
            }
        }
    }
}