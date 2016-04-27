using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class BBSReply
    {
        //通过工厂 创建数据访问层对象
        private readonly IDAL.IBBSReply dal = DALFactory.DataAccess.CreatBBSReply();
        /// <summary>
        /// 增加一条回帖记录
        /// </summary>
        /// <param name="txtreply">回帖内容</param>
        /// <param name="txttitle">回帖标题</param>
        /// <param name="tid">主贴编号</param>
        /// <param name="sid">板块编号</param>
        /// <param name="id">用户编号</param>
        /// <returns>回帖编号</returns>
        public int add(string txtreply, string txttitle, int tid, int sid,int id)
        {

            return dal.add(txtreply, txttitle, tid, sid, id);
        }
        
    }
}
