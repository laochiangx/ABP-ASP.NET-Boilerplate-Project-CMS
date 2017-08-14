using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.EntityFramework
{
   public class ContextFactory
    {        /// <summary>
             /// 获取当前数据上下文
             /// </summary>
             /// <returns></returns>
        public static JCMSDbContext GetCurrentContext()
        {
            JCMSDbContext db = CallContext.GetData("Default") as JCMSDbContext;
            if (db == null)
            {
                db = new JCMSDbContext();
                CallContext.SetData("Default", db);
            }
            return db;
        }

        public static void GetCurrentContextSetDatabaseExecuteSqlCommand(string FullName)
        {
            JCMSDbContext db = CallContext.GetData("Default") as JCMSDbContext;
            db.Database.ExecuteSqlCommand(System.IO.File.ReadAllText(FullName, Encoding.Default));
        }
    }
}
