using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace IDAL
{
   public interface IAdmin
    {
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns>用户编号</returns>
        int add(Model.Admin model);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户姓名</param>
        /// <param name="pwd">用户密码</param>
        /// <returns>用户编号</returns>
        int Login(string name, string pwd);

        /// <summary>
        /// 获取最新几个用户
        /// </summary>
        /// <param name="top">前top个</param>
        /// <returns></returns>
        DataSet GetList(int top);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <returns>对象实体</returns>
        Model.Admin GetModel(int Uid);

        /// <summary>
        /// 判断是否为管理员
        /// </summary>
        /// <param name="n">用户编号</param>
        /// <returns>管理员编号</returns>
        int IfAdmin(int n);
      
    }
}
