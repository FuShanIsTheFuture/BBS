using System;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
	/// <summary>
	/// 抽象工厂模式创建DAL。
	/// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口) 
	/// DataCache类在导出代码的文件夹里
	/// <appSettings> 
	/// <add key="DAL" value="SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess
	{
		private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
		/// <summary>
		/// 创建对象或从缓存获取
		/// </summary>
		public static object CreateObject(string AssemblyPath,string ClassNamespace)
		{
			object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
					DataCache.SetCache(ClassNamespace, objType);// 写入缓存
				}
				catch
				{}
			}
			return objType;
		}
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        /// <summary>
        /// 创建数据层接口
        /// </summary>
        //public static t Create(string ClassName)
        //{
        //string ClassNamespace = AssemblyPath +"."+ ClassName;
        //object objType = CreateObject(AssemblyPath, ClassNamespace);
        //return (t)objType;
        //}
        /// <summary>
        /// 创建Admin数据层接口。
        /// </summary>
        /*
        public static IDAL.IAdmin CreateAdmin()
		{

			string ClassNamespace = AssemblyPath +".Admin";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IDAL.IAdmin)objType;
		}
        */
        
        public static IDAL.IAdmin CreateAdmin() //每增加一个数据接口 就需要到dataacess里增加一个方法
        {
            string ClassNamespace = AssemblyPath + ".Admin";//双引号里的内容
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IAdmin)objType;//返回的类型
        }
        public static IDAL.IBBSTopic CreateBBSTopic() //每增加一个数据接口 就需要到dataacess里增加一个方法
        {
            string ClassNamespace = AssemblyPath + ".BBSTopic";//双引号里的内容
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IBBSTopic)objType;//返回的类型
        }
        public static IDAL.IBBSSection CreateBBSSection() //每增加一个数据接口 就需要到dataacess里增加一个方法
        {
            string ClassNamespace = AssemblyPath + ".BBSSection";//双引号里的内容
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IBBSSection)objType;//返回的类型
        }
        public static IDAL.IBBSReply CreatBBSReply() //每增加一个数据接口 就需要到dataacess里增加一个方法
        {
            string ClassNamespace = AssemblyPath + ".BBSReply";//双引号里的内容
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IBBSReply)objType;//返回的类型
        }

    }
}