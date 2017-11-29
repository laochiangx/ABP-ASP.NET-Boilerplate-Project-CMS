using Hangfire.Common;
using Hangfire.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABPCMS.Web.App_Start
{
    public class TextBufferLogProvider : ILogProvider
    {
        public ILog GetLogger(string name)
        {
            return new TextBufferLog();
        }

        public class TextBufferLog : ILog
        {
            public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception)
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                JobHelper.SetSerializerSettings(settings);

                if (messageFunc == null)
                {
                    return logLevel >= LogLevel.Info;
                }

                TextMessageBuffer.WriteLine(messageFunc());
                return true;
            }
        }
    }
}