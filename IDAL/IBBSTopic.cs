using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IDAL
{
    public interface IBBSTopic
    {
        /// <summary>
        /// 获取前几行主贴列表
        /// </summary>
        /// <param name="top">前top行</param>
        /// <returns>数据表</returns>
        DataSet GetList(int top);

        /// <summary>
        /// 获取前几行主贴轮播
        /// </summary>
        /// <returns>数据表</returns>
        DataSet GetModels();

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <returns>对象实体</returns>
        Model.BBSTopic GetModel(int Uid);

        DataSet GetList(string strWhere);
        bool DeleteList(string adminIDlist);

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns>用户编号</returns>
        int add(Model.BBSTopic model);

        /// <summary>
        /// 点赞数加1
        /// </summary>
        /// <param name="tid">帖子编号</param>
        /// <returns>点赞与否</returns>
        bool changegood(int tid);
    }
}
