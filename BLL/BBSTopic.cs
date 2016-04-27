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
    }
}
