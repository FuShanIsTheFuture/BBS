using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    
    public class BBSSection
    {
        private readonly IDAL.IBBSSection dal = DALFactory.DataAccess.CreateBBSSection();

        /// <summary>
        /// 获取相应板块的内容列表
        /// </summary>
        /// <param name="sid">板块编号</param>
        /// <param name="top">前几条</param>
        /// <returns>数据列表</returns>
        public DataSet GetList(int sid, int top)
        {
            return dal.GetList(sid, top);
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

    }
}
