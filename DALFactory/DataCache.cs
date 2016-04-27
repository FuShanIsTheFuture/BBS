using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web; 

namespace DALFactory
{
   public class DataCache
    {
        /// 
        /// 获取当前应用程序指定CacheKey的Cache值 
        ///  
        ///  
        ///  
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// 
        /// 设置当前应用程序指定CacheKey的Cache值 
        ///  
        ///  
        ///  
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        } 
    }
}
