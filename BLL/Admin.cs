using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BLL
{
  public  class Admin
    {
        //通过工厂 创建数据访问层对象
        private readonly IDAL.IAdmin dal = DALFactory.DataAccess.CreateAdmin();
        
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int add(Model.Admin model)
        {

          return  dal.add(model);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name, string pwd)
        {

            return dal.Login(name, pwd);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataSet GetList(int top)
        {
            return dal.GetList(top);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <returns>对象实体</returns>
        public Model.Admin GetModel(int Uid)
        {

            return dal.GetModel(Uid);
        }

        /// <summary>
        /// 判断是否为管理员
        /// </summary>
        /// <param name="n">用户编号</param>
        /// <returns>管理员编号</returns>
        public int IfAdmin(int n)
        {
            return dal.IfAdmin(n);
        }
    }
}
