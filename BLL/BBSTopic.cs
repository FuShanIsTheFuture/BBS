using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class BBSTopic
    {
        private readonly IDAL.IBBSTopic dal = DALFactory.DataAccess.CreateBBSTopic();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="top">前几行</param>
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
        public Model.BBSTopic GetModel(int Uid)
        {

            return dal.GetModel(Uid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string adminIDlist)
        {
            return dal.DeleteList(adminIDlist);
        }

        /// <summary>
        /// 增加帖子
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int add(Model.BBSTopic model)
        {

            return dal.add(model);
        }

        public bool changegood(int tid)
        {
            return dal.changegood(tid);
        }
        /// <summary>
        /// 获取前几行主贴轮播
        /// </summary>
        /// <param name="top">前top行</param>
        /// <returns>数据表</returns>
        public DataSet GetModels()
        {
            return dal.GetModels();
        }
    }
}
