using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;

namespace SQLServerDAL
{
    public class BBSReply:IDAL.IBBSReply
    {
        /// <summary>
        /// 增加一条回帖记录
        /// </summary>
        /// <param name="txtreply">回帖内容</param>
        /// <param name="txttitle">回帖标题</param>
        /// <param name="tid">主贴编号</param>
        /// <param name="sid">板块编号</param>
        /// <returns>回帖编号</returns>
        public int add(string txtreply, string txttitle, int tid, int sid,int id)
        {
            string sql = string.Format(@"INSERT INTO [dbo].[BBSReply]
           ([RTID]
            ,[RSID]
           ,[RUID]
           ,[RTopic]
           ,[RContents])
     VALUES
           ({0},{1},{2},'{3}','{4}')",tid,sid,id,txttitle,txtreply);

            object obj = DbHelperSQL.GetSingle(sql);

            sql = string.Format(@"select top 1 RID from BBSReply order by RTime desc");

            obj = DbHelperSQL.GetSingle(sql);

            if (Convert.ToInt32(obj) > 0)
            {
                return Convert.ToInt32(obj);
            }
            return -1;
        }

        /// <summary>
        /// 返回前几条回帖记录
        /// </summary>
        /// <param name="Top">前TOP条</param>
        /// <returns></returns>
        public DataSet GetList(int tid,int Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RUID,RTopic,RContents ");
            strSql.Append(" FROM BBSReply ");
            strSql.Append(" where RTID="+tid+" ");
            strSql.Append(" order by RTime desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
